using DocumentUploader.Core.Models;
using NUnit.Framework;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class CredentialsFileTest {
    [Test]
    public void TestDefaultsToNull() {
      var credentials = new CredentialsFile();
      Assert.Null(credentials.ClientID);
      Assert.Null(credentials.ClientSecret);
    }

    [Test]
    public void TestValuesCanBeInlaidCorrectly() {
      var credentials = new CredentialsFile {ClientID = "123", ClientSecret = "456"};

      Assert.That(credentials.ClientID, Is.EqualTo("123"));
      Assert.That(credentials.ClientSecret, Is.EqualTo("456"));
    }
  }
}