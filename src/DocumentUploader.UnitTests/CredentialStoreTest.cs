using System;
using System.IO;
using DocumentUploader.Core.Models;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class CredentialStoreTest : BaseTestCase {
    [Test]
    public void TestGetWithRealPathGivesCorrectValues() {
      mFile.Setup(f => f.ReadAllLines("fakePath.txt")).Returns(new[] {"1", "2"});
      Assert.That(mCredStore.Get().ClientID, Is.EqualTo("1"));
      Assert.That(mCredStore.Get().ClientSecret, Is.EqualTo("2"));
    }

    [Test]
    public void TestGetWithInvalidPathThrowsAnException() {
      mFile.Setup(f => f.ReadAllLines("fakePath.txt")).Throws(new FileNotFoundException());
      Assert.Throws(typeof(FileNotFoundException), () => mCredStore.Get());
    }

    [Test]
    public void TestThatUpdateGrabsCorrectValues() {
      mFile.Setup(f => f.WriteAllText("fakePath.txt", string.Format("{0}{1}{2}", "1", Environment.NewLine, "2")));
      mCredStore.Update(new CredentialsFile {ClientID = "1", ClientSecret = "2"});
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mCredStore = new CredentialStore(mFile.Object, "fakePath.txt");
    }

    private Mock<IFile> mFile;
    private CredentialStore mCredStore;
  }
}