using System;
using DocumentUploader.Core.Models;
using Goul.Core;
using Goul.Core.Tokens;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests.Models {
  [TestFixture]
  public class CredentialStoreTest : BaseTestCase {
    [Test]
    public void TestGetWithCorrectPathReturnsValues() {
      mFile.Setup(f => f.ReadAllLines("credentials.txt")).Returns(new[] { "1", "2" });
      Assert.That(mStore.Get().ClientID, Is.EqualTo("1"));
      Assert.That(mStore.Get().ClientSecret, Is.EqualTo("2"));
    }

    [Test]
    public void TestThatUpdateChangesTheValuesOfTheFile() {
      mFile.Setup(f => f.WriteAllText("credentials.txt", string.Format("{0}{1}{2}", "1", Environment.NewLine, "2")));
      mStore.Update(new Credentials {ClientID = "1", ClientSecret = "2"});
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mStore = new CredentialStore(mFile.Object, "credentials.txt");
    }

    private Mock<IFile> mFile;
    private ICredentialStore mStore;
  }
}