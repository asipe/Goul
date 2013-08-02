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
  public class SetCredentialsTest:BaseTestCase {
    [Test]
    public void TestThatCustomCredentialsAreSet() {
      mApp.Execute("setcredentials", "val1", "val2");
      var credentialsFileLines = mFile.ReadAllLines("credentials.txt");
      Assert.That(credentialsFileLines, Is.EqualTo(BA("val1", "val2")));
      Assert.That(mMessageObserver.GetMessageCache(), Is.EqualTo(BA("Credentials Set")));
    }

    [Test]
    public void TestThatTheAppThrowsCorrectExceptionWhenGivenIncorrectNumberOfArgs() {
      mApp.Execute("setcredentials");
      Assert.That(mMessageObserver.GetMessageCache(), Is.EqualTo(BA("Invalid amount of arguments")));
      mApp.Execute(new[] {"setcredentials", "heyo"});
      Assert.That(mMessageObserver.GetMessageCache(), Is.EqualTo(BA("Invalid amount of arguments")));
      mApp.Execute(new[] {"setcredentials", "heyo", "yayo", "mayo"});
      Assert.That(mMessageObserver.GetMessageCache(), Is.EqualTo(BA("Invalid amount of arguments")));
    }

    [SetUp]
    public void DoSetup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mMessageObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
    }

    [TearDown]
    public void DoTearDown() {
      mFile.Delete("credentials.txt");
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mMessageObserver;
    private IApp mApp;
  }
}