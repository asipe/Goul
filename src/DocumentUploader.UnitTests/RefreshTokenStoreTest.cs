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
    public void TestGetWithCorrectPathReturnsValues() {
      mFile.Setup(f => f.ReadAllLines("credentials.txt")).Returns(new[] { "1" });
      Assert.That(mStore.Get().Token, Is.EqualTo("1"));
    }

    [Test]
    public void TestUpdateSetsTheValuesForTheFile() {
      mFile.Setup(f => f.WriteAllText("credentials.txt", "1"));
      mStore.Update(new RefreshToken {Token = "1"});
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mStore = new RefreshTokenStore(mFile.Object, "credentials.txt");
    }

    private Mock<IFile> mFile;
    private RefreshTokenStore mStore;
  }
}