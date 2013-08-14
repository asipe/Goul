using Goul.Core.Tokens;
using NUnit.Framework;

namespace DocumentUploader.UnitTests.Models {
  [TestFixture]
  public class CredentialsFileTest {
    [Test]
    public void TestDefaultsToNull() {
      var credentials = new Credentials();
      Assert.Null(credentials.ClientID);
      Assert.Null(credentials.ClientSecret);
    }

    [Test]
    public void TestValuesCanBeInlaidCorrectly() {
      var credentials = new Credentials {ClientID = "123", ClientSecret = "456"};

      Assert.That(credentials.ClientID, Is.EqualTo("123"));
      Assert.That(credentials.ClientSecret, Is.EqualTo("456"));
    }
  }
}