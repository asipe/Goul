using DocumentUploader.Core.Command;
using DocumentUploader.Core.Observer;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class HelpCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteAddsOneCorrectMessageToTheObserver() {
      mMessageObserver.Setup(o => o.AddMessages("Goul Document Uploader Version 0.1", "Commands:", "setcredentials xClient_IDx xClient_Secretx | Sets the client id and the client secret to a local .txt file", "listcredentials | lists the credentials", "clearcredentials | deletes ALL of the credential files"));
      mHCommand.Execute("message");
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