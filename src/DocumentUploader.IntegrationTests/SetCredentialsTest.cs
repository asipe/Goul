using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using DocumentUploader.IntegrationTests.Infrastructure.Modules;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class SetCredentialsTest {
    [Test]
    public void TestThatCorrectMessageIsSent() {
      mApp.Execute(new[] {"setcredentials", "123", "324"});
      Assert.That(mMessageObserver.GetMessageCache()[0], Is.EqualTo(("Credentials Set")));
    }

    [Test]
    public void TestThatCredentialsAreActuallySet() {
      mApp.Execute(new[] {"setcredentials", "123", "456"});
      var credentialsFileLines = mFile.ReadAllLines("credentials.txt");
      Assert.That(credentialsFileLines[0], Is.EqualTo(("123")));
      Assert.That(credentialsFileLines[1], Is.EqualTo(("456")));
      Assert.That(mMessageObserver.GetMessageCache()[0], Is.EqualTo(("Credentials Set")));
    }

    [Test]
    public void TestThatCustomCredentialsAreSet() {
      mApp.Execute(new[] {"setcredentials", "val1", "val2"});
      var credentialsFileLines = mFile.ReadAllLines("credentials.txt");
      Assert.That(credentialsFileLines[0], Is.EqualTo(("val1")));
      Assert.That(credentialsFileLines[1], Is.EqualTo(("val2")));
      Assert.That(mMessageObserver.GetMessageCache()[0], Is.EqualTo(("Credentials Set")));
    }

    [Test]
    public void TestThatTheAppThrowsCorrectExceptionWhenGivenIncorrectNumberOfArgs() {
      mApp.Execute(new[] {"setcredentials"});
      Assert.That(mMessageObserver.GetMessageCache()[0], Is.EqualTo("Invalid amount of arguments"));
      mApp.Execute(new[] {"setcredentials", "heyo"});
      Assert.That(mMessageObserver.GetMessageCache()[0], Is.EqualTo("Invalid amount of arguments"));
      mApp.Execute(new[] {"setcredentials", "heyo", "yayo", "mayo"});
      Assert.That(mMessageObserver.GetMessageCache()[0], Is.EqualTo("Invalid amount of arguments"));
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