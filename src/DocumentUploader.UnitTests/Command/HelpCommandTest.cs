using DocumentUploader.Core.Command;
using DocumentUploader.Core.Observer;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests.Command {
  [TestFixture]
  public class HelpCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteAddsOneCorrectMessageToTheObserver() {
      mObserver.Setup(o => o.AddMessages("Goul Document Uploader Version 0.1", "Commands:", "setcredentials xClient_IDx xClient_Secretx | Sets the client id and the client secret to a local .txt file", "listcredentials | lists the credentials", "clearcredentials | deletes ALL of the credential files"));
      mCommand.Execute("message");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mCommand = new HelpCommand(mObserver.Object);
    }

    private Mock<IMessageObserver> mObserver;
    private ICommand mCommand;
  }
}