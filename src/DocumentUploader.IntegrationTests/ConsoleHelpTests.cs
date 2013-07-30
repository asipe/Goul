using NUnit.Framework;
using DocumentUploader.Core;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class ConsoleHelpTests {
    [Test]
    public void TestSetupHelp() {
      var consoleObserver = new ConsoleObserver();
      var app = new App(new HelpCommand(consoleObserver));
      app.Execute(new[] {"help"});
      Assert.That(consoleObserver.GetMessageCache()[0], Is.EqualTo("help"));
    }
  }
}