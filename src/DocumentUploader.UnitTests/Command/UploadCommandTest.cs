using System;
using DocumentUploader.Core.Command;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core.Adapter;
using Goul.Core.Tokens;
using Moq;
using NUnit.Framework;

namespace DocumentUploader.UnitTests.Command {
  [TestFixture]
  public class UploadCommandTest : DocumentUploaderBaseTestCase {
    [Test]
    public void TestUploadMessageIsSentWithNoFoldersAdded() {
      mObserver.Setup(o => o.AddMessages("Files uploaded"));
      mRefreshTokenStore.Setup(s => s.Get()).Returns(new RefreshToken {Token = "1"});
      mHandler.Setup(h => h.UploadFileWithFolder("file", "fileTitle", It.Is<string[]>(a => AreEqual(a, new string[] {})), It.Is<Credentials>(c => AreEqual(c, new Credentials {ClientID = "1", ClientSecret = "2"})), It.Is<RefreshToken>(t => AreEqual(t, new RefreshToken {Token = "1"}))));
      mCredentialStore.Setup(r => r.Get()).Returns(new Credentials {ClientID = "1", ClientSecret = "2"});
      mCommand.Execute("upload", "file", "fileTitle");
    }

    [Test]
    public void TestCommandWithFoldersAdded() {
      mObserver.Setup(o => o.AddMessages("Files uploaded"));
      mRefreshTokenStore.Setup(s => s.Get()).Returns(new RefreshToken { Token = "1" });
      mHandler.Setup(h => h.UploadFileWithFolder("file", "fileTitle", It.Is<string[]>(a => AreEqual(a, new[] { "folder", "fileTitle" })), It.Is<Credentials>(c => AreEqual(c, new Credentials { ClientID = "1", ClientSecret = "2" })), It.Is<RefreshToken>(t => AreEqual(t, new RefreshToken { Token = "1" }))));
      mCredentialStore.Setup(c => c.Get()).Returns(new Credentials { ClientID = "1", ClientSecret = "2" });
      mCommand.Execute("upload", "file", @"folder\fileTitle");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mHandler = Mok<IGoulRequestHandler>();
      mRefreshTokenStore = Mok<IRefreshTokenStore>();
      mCredentialStore = Mok<ICredentialStore>();
      mCommand = new UploadCommand(mObserver.Object, mHandler.Object, mCredentialStore.Object, mRefreshTokenStore.Object);
    }

    private Mock<IMessageObserver> mObserver;
    private Mock<IGoulRequestHandler> mHandler;
    private Mock<ICredentialStore> mCredentialStore;
    private Mock<IRefreshTokenStore> mRefreshTokenStore;
    private ICommand mCommand;
  }
}