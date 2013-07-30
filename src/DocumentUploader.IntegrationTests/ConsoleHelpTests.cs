using NUnit.Framework;
using DocumentUploader.Core;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class ConsoleHelpTests {
    [Test]
    public void TestSetupHelp() {
      var app = new App();
      var consoleObserver = new ConsoleObserver();

      app.Execute("help");
      Assert.That(consoleObserver.GetMostRecentMessage(), Is.EqualTo("<help message>"));
     
    }
  }
}