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
      Assert.That(messageObserver.GetCommandCache(), Is.EqualTo(BA("help")));
      //
      //Goul Document Uploader Version 0.0.0.1
      //
      //  help    #this message
      //  auth    #blah
      //
    }
  }
}