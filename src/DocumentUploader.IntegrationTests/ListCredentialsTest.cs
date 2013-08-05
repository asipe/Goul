using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using DocumentUploader.IntegrationTests.Infrastructure.Modules;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class ListCredentialsTest : BaseTestCase {
    [Test]
    public void TestThatProperValuesAreListed() {
      mApp.Execute("setcredentials", "randomVal", "seeminglyRandomVal");
      mApp.Execute("listcredentials");

      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(mFile.ReadAllLines("credentials.txt")));
      mFile.Delete("credentials.txt");
    }

    [Test]
    public void TestThatWhenTheCredentialsFileIsMissingTheCorrectMessageIsShown() {
      mApp.Execute("listcredentials");

      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(BA("Could not find the Credentials file")));
    }

    [Test]
    public void TestWhenThereIsOnlyOneCredentialTheListCommandWorks() {
      mFile.WriteAllText("credentials.txt", "val1");
      mApp.Execute("listcredentials");

      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(mFile.ReadAllLines("credentials.txt")));
      mFile.Delete("credentials.txt");
    }

    [SetUp]
    public void DoSetup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mMessageObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
      mApp.Execute("setCredentials", "val1", "val2");
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mMessageObserver;
    private IApp mApp;
  }
}