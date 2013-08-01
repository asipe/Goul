using DocumentUploader.Core;
using DocumentUploader.Core.Command;
using DocumentUploader.Core.Observer;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class SetCredentialsTest : BaseTestCase {
    [Test]
    public void TestExecuteAddsOneCorrectMessageToTheObserver() {
      mMessageObserver.Setup(o => o.AddMessages(new[] {"Credentials Set"}));
      mSetCredentialsCommand.Execute(new[] { "setcredentials", "1", "2" });
    }

    [SetUp]
    public void DoSetup() {
      mMessageObserver = Mok<IMessageObserver>();
      mSetCredentialsCommand = new SetCredentialsCommand(mMessageObserver.Object);
    }

    private Mock<IMessageObserver> mMessageObserver;
    private ICommand mSetCredentialsCommand;

  }
}