using System;
using System.IO;
using Goul.Console.Core;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace Goul.UnitTests.Console.Core {
  [TestFixture]
  public class RefreshTokenRepositoryTest : BaseTestCase {
    [Test]
    public void TestLoadingABasicTextFile() {
      mFile.Setup(f => f.ReadAllLines("testFile.txt")).Returns(new[] { "1", "2" });
      Assert.That(mRRepo.Load(), Is.EqualTo(new[] {"1", "2"}));
    }

    [Test]
    public void TestLoadingAnEmptyTextFileReturnsEmptyArray() {
      mFile.Setup(f => f.ReadAllLines("testFile.txt")).Returns(new string[] {});
      Assert.That(mRRepo.Load(), Is.EqualTo(new string[] {}));
    }

    [Test]
    public void TestRefreshTokenFileExistsReturnsFalse() {
      mFile.Setup(f => f.Exists("testFile.txt")).Returns(false);
      Assert.That(mRRepo.Exists(), Is.False);
    }

    [Test]
    public void TestRefreshTokenFileExistsReturnsTrue() {
      mFile.Setup(f => f.Exists("testFile.txt")).Returns(true);
      Assert.That(mRRepo.Exists(), Is.True);
    }

    [Test]
    public void TestLoadingANonexistantFileThrows() {
      mFile.Setup(f => f.ReadAllLines("testFile.txt")).Throws(new FileNotFoundException());
      Assert.Throws(typeof(FileNotFoundException), ()=> mRRepo.Load());    
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mRRepo = new RefreshTokenRepository(mFile.Object, "testFile.txt");
    }

    private Mock<IFile> mFile;
    private RefreshTokenRepository mRRepo;
  }
}