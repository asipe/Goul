using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using NUnit.Framework;
using DocumentUploader.Core;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class ConsoleHelpTests:BaseTestCase {
    [Test]
    public void TestHelpCommandIsSentCorrectly() {
      var factory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      var messageObserver = (ConsoleObserver)factory.Build<IMessageObserver>();
      var app = factory.Build<IApp>();
      app.Execute(new[] {"help"});
      Assert.That(messageObserver.GetMessageCache()[0], Is.EqualTo(("Goul Document Uploader Version 0.1")));
      Assert.That(messageObserver.GetMessageCache()[1], Is.EqualTo(("Commands:")));
      Assert.That(messageObserver.GetMessageCache()[2], Is.EqualTo(("setcredentials xClient_IDx xClient_Secretx")));
    }
  }
}