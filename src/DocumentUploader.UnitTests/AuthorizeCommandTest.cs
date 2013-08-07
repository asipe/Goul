using DocumentUploader.Core.Command;
using DocumentUploader.Core.Observer;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class AuthorizeCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteAddsOneCorrectMessageToTheObserver() {
      mMessageObserver.Setup(o => o.AddMessages("Authorized"));
      mACommand.Execute("authorize");
    }

    [SetUp]
    public void DoSetup() {
      mMessageObserver = Mok<IMessageObserver>();
      mACommand = new AuthorizeCommand(mMessageObserver.Object);
    }

    private Mock<IMessageObserver> mMessageObserver;
    private ICommand mACommand;
  }
}