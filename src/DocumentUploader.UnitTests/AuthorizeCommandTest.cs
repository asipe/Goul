using DocumentUploader.Core.Command;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;
using Moq;
using NUnit.Framework;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class AuthorizeCommandTest : DocumentUploaderBaseTestCase {
    [Test]
    public void TestExecuteAddsOneCorrectMessageToTheObserver() {
      mMessageObserver.Setup(o => o.AddMessages("Authorized"));
      mRefreshTokenStore.Setup(s => s.Update(It.Is<RefreshToken>(t => AreEqual(t, new RefreshToken {Token = "123"}))));
      mGReqHandler.Setup(r => r.CreateRefreshToken(It.Is<Credentials>(c => AreEqual(c, new Credentials {ClientID = "1", ClientSecret = "2"})), "123")).Returns("123");
      mCredStore.Setup(r => r.Get()).Returns(new Credentials {ClientID = "1", ClientSecret = "2"});
      mACommand.Execute("authorize", "123");
    }

    [SetUp]
    public void DoSetup() {
      mMessageObserver = Mok<IMessageObserver>();
      mRefreshTokenStore = Mok<IRefreshTokenStore>();
      mCredStore = Mok<ICredentialStore>();
      mGReqHandler = Mok<IGoulRequestHandler>();
      mACommand = new AuthorizeCommand(mMessageObserver.Object, mRefreshTokenStore.Object, mCredStore.Object, mGReqHandler.Object);
    }

    private Mock<IMessageObserver> mMessageObserver;
    private Mock<IRefreshTokenStore> mRefreshTokenStore;
    private Mock<ICredentialStore> mCredStore;
    private Mock<IGoulRequestHandler> mGReqHandler;
    private ICommand mACommand;
  }
}