using DocumentUploader.Core.Command;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using NUnit.Framework;
using DocumentUploader.Core;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class ConsoleHelpTests:BaseTestCase {
    [Test]
    public void TestSetupHelp() {
      var factory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      var messageObserver = (ConsoleObserver)factory.Build<IMessageObserver>();
      var app = factory.Build<IApp>();
      app.Execute(new[] {""});
      Assert.That(messageObserver.GetMessageCache()[0], Is.EqualTo(BA("help")));
    }
    //public void TestSetupHelp() {
    //  var consoleObserver = new ConsoleObserver();
    //  var app = new App(new HelpCommand(consoleObserver));
    //  app.Execute(new[] {"help"});
    //  Assert.That(consoleObserver.GetMessageCache()[0], Is.EqualTo("help"));
    //}
  }
}