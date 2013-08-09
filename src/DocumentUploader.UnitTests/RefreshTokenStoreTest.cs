using System.IO;
using DocumentUploader.Core.Models;
using Goul.Core;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class RefreshTokenStoreTest : BaseTestCase {
    [Test]
    public void TestGetWithRealPathGivesCorrectValues() {
      mFile.Setup(f => f.ReadAllLines("fakePath.txt")).Returns(new[] {"1"});
      Assert.That(mRefreshTokenStore.Get().Token, Is.EqualTo("1"));
    }

    [Test]
    public void TestGetWithInvalidPathThrowsAnException() {
      mFile.Setup(f => f.ReadAllLines("fakePath.txt")).Throws(new FileNotFoundException());
      Assert.Throws(typeof(FileNotFoundException), () => mRefreshTokenStore.Get());
    }

    [Test]
    public void TestThatUpdateGrabsCorrectValues() {
      mFile.Setup(f => f.WriteAllText("fakePath.txt", "1"));
      mRefreshTokenStore.Update(new RefreshToken {Token = "1"});
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mRefreshTokenStore = new RefreshTokenStore(mFile.Object, "fakePath.txt");
    }

    private Mock<IFile> mFile;
    private RefreshTokenStore mRefreshTokenStore;
  }
}