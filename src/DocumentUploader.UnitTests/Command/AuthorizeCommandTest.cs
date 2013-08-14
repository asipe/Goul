using DocumentUploader.Core.Command;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;
using Goul.Core.Adapter;
using Goul.Core.Tokens;
using Moq;
using NUnit.Framework;

namespace DocumentUploader.UnitTests.Command {
  [TestFixture]
  public class AuthorizeCommandTest : DocumentUploaderBaseTestCase {
    [Test]
    public void TestExecuteAddsOneCorrectMessageToTheObserver() {
      mObserver.Setup(o => o.AddMessages("Authorized"));
      mRefreshTokenStore.Setup(s => s.Update(It.Is<RefreshToken>(t => AreEqual(t, new RefreshToken {Token = "123"}))));
      mHandler.Setup(r => r.CreateRefreshToken(It.Is<Credentials>(c => AreEqual(c, new Credentials {ClientID = "1", ClientSecret = "2"})), "123")).Returns("123");
      mCredentialStore.Setup(r => r.Get()).Returns(new Credentials {ClientID = "1", ClientSecret = "2"});
      mCommand.Execute("authorize", "123");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mRefreshTokenStore = Mok<IRefreshTokenStore>();
      mCredentialStore = Mok<ICredentialStore>();
      mHandler = Mok<IGoulRequestHandler>();
      mCommand = new AuthorizeCommand(mObserver.Object, mRefreshTokenStore.Object, mCredentialStore.Object, mHandler.Object);
    }

    private Mock<IMessageObserver> mObserver;
    private Mock<IRefreshTokenStore> mRefreshTokenStore;
    private Mock<ICredentialStore> mCredentialStore;
    private Mock<IGoulRequestHandler> mHandler;
    private ICommand mCommand;
  }
}