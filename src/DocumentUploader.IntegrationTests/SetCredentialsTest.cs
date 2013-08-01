using DocumentUploader.Core;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class SetCredentialsTest {
    [Test]
    public void TestThatCorrectMessageIsSent() {
      var factory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      var messageObserver = (ConsoleObserver)factory.Build<IMessageObserver>();
      var app = factory.Build<IApp>();
      
      app.Execute(new[] { "setcredentials", "123", "324" });
      
      Assert.That(messageObserver.GetMessageCache()[0], Is.EqualTo(("Credentials Set")));
    }

    [Test]
    public void TestThatCredentialsAreActuallySet() {
      var factory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      var app = factory.Build<IApp>();
      var messageObserver = (ConsoleObserver)factory.Build<IMessageObserver>();
      app.Execute(new[] { "setcredentials", "123", "456" });

      var credentialsFileLines = mFile.ReadAllLines("credentials.txt");
      Assert.That(credentialsFileLines[0], Is.EqualTo(("123")));
      Assert.That(credentialsFileLines[1], Is.EqualTo(("456")));
      Assert.That(messageObserver.GetMessageCache()[0], Is.EqualTo(("Credentials Set")));
      
      mFile.Delete("credentials.txt");
    }

    [Test]
    public void TestThatCustomCredentialsAreSet() {
      var factory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      var app = factory.Build<IApp>();
      var messageObserver = (ConsoleObserver)factory.Build<IMessageObserver>();
      app.Execute(new[] { "setcredentials", "val1", "val2" });

      var credentialsFileLines = mFile.ReadAllLines("credentials.txt");
      Assert.That(credentialsFileLines[0], Is.EqualTo(("val1")));
      Assert.That(credentialsFileLines[1], Is.EqualTo(("val2")));
      Assert.That(messageObserver.GetMessageCache()[0], Is.EqualTo(("Credentials Set")));

      mFile.Delete("credentials.txt");
    }

    [Test]
    public void TestThatTheAppThrowsCorrectExceptionWhenGivenIncorrectNumberOfArgs() {
      var factory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      var app = factory.Build<IApp>();
      var messageObserver = (ConsoleObserver)factory.Build<IMessageObserver>();

      app.Execute(new [] {"setcredentials"});
      Assert.That(messageObserver.GetMessageCache()[0], Is.EqualTo("Invalid amount of arguments"));

      app.Execute(new[] { "setcredentials", "heyo" });
      Assert.That(messageObserver.GetMessageCache()[0], Is.EqualTo("Invalid amount of arguments"));

      app.Execute(new[] { "setcredentials", "heyo", "yayo", "mayo" });
      Assert.That(messageObserver.GetMessageCache()[0], Is.EqualTo("Invalid amount of arguments"));

      mFile.Delete("credentials.txt");
    }

    [SetUp]
    public void DoSetup() {
      mFile = new DotNetFile();
    }

    private DotNetFile mFile;
  }
}