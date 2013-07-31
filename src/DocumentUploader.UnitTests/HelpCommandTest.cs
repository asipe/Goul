using DocumentUploader.Core;
using DocumentUploader.Core.Command;
using DocumentUploader.Core.Observer;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class HelpCommandTest:BaseTestCase {
     [Test]
     public void TestExecuteAddsOneCorrectMessageToTheObserver() {
       var cmdMessage = "";
       mMessageObserver.Setup(o => o.AddMessage("message")).Callback(() => cmdMessage = "message sent");
       mHCommand.Execute(new[] {"message"});
       Assert.That(cmdMessage, Is.EqualTo("message sent"));
     }

     [SetUp]
     public void DoSetup() {
       mMessageObserver = Mok<IMessageObserver>();
       mHCommand = new HelpCommand(mMessageObserver.Object);
     }

     private Mock<IMessageObserver> mMessageObserver;
     private ICommand mHCommand;
  }
}