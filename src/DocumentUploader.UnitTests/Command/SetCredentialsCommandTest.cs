using DocumentUploader.Core.Command;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core.Tokens;
using Moq;
using NUnit.Framework;

namespace DocumentUploader.UnitTests.Command {
  [TestFixture]
  public class SetCredentialsCommandTest : DocumentUploaderBaseTestCase {
    [Test]
    public void TestThatCredentialsAreSetWhenThereAre3Args() {
      mObserver.Setup(o => o.AddMessages("Credentials Set"));
      mStorage.Setup(s => s.Update(It.Is<Credentials>(c => AreEqual(c, new Credentials {ClientID = "1", ClientSecret = "2"}))));
      mCommand.Execute("setcredentials", "1", "2");
    }

    [Test]
    public void TestThatCredentialsAreNotSetWhenThereAreLessThan3Args() {
      mObserver.Setup(o => o.AddMessages("Invalid amount of arguments"));
      mCommand.Execute("setcredentials");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mStorage = Mok<ICredentialStore>();
      mCommand = new SetCredentialsCommand(mObserver.Object, mStorage.Object);
    }

    private ICommand mCommand;
    private Mock<IMessageObserver> mObserver;
    private Mock<ICredentialStore> mStorage;
  }
}