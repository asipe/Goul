using DocumentUploader.Core.Command;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;
using Moq;
using NUnit.Framework;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class UploadCommandTest : DocumentUploaderBaseTestCase {
    [Test]
    public void TestUploadMessageIsSent() {
      mObserver.Setup(o => o.AddMessages("File uploaded"));
      mRefreshStore.Setup(s => s.Get()).Returns(new RefreshToken {Token = "1"});
      mHandler.Setup(h => h.UploadFile("file", "fileTitle", It.Is<Credentials>(c => AreEqual(c, new Credentials {ClientID = "1", ClientSecret = "2"})), It.Is<RefreshToken>(t => AreEqual(t, new RefreshToken {Token = "1"}))));
      mCredentialStore.Setup(r => r.Get()).Returns(new Credentials {ClientID = "1", ClientSecret = "2"});
      mCommand.Execute("upload", "file", "fileTitle");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mHandler = Mok<IGoulRequestHandler>();
      mRefreshStore = Mok<IRefreshTokenStore>();
      mCredentialStore = Mok<ICredentialStore>();
      mCommand = new UploadCommand(mObserver.Object, mHandler.Object, mCredentialStore.Object, mRefreshStore.Object);
    }

    private Mock<IMessageObserver> mObserver;
    private Mock<IGoulRequestHandler> mHandler;
    private Mock<ICredentialStore> mCredentialStore;
    private Mock<IRefreshTokenStore> mRefreshStore;
    private ICommand mCommand;
  }
}