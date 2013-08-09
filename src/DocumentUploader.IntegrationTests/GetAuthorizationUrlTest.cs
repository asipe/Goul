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
  public class GetAuthorizationUrlTest : BaseTestCase {
    [Test]
    public void TestAuthorizationUrlIsCorrect() {
      mApp.Execute("setcredentials", "randomVal", "seeminglyRandomVal");
      mApp.Execute("getauthorizationurl");

      var messages = mMessageObserver.GetMessages();
      Assert.That(messages.Length, Is.EqualTo(1));
      Assert.That(messages[0], Is.StringStarting("https://accounts.google.com/o/oauth2"));

      mFile.Delete("credentials.txt");
    }

    [SetUp]
    public void DoSetup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mMessageObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mMessageObserver;
    private IApp mApp;
  }
}