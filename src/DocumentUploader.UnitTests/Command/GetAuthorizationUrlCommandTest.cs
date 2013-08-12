using DocumentUploader.Core.Command;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;
using Moq;
using NUnit.Framework;

namespace DocumentUploader.UnitTests.Command {
  [TestFixture]
  public class GetAuthorizationUrlCommandTest : DocumentUploaderBaseTestCase {
    [Test]
    public void TestGetAuthUrlCommandWorks() {
      mStore.Setup(o => o.Get()).Returns(new Credentials {ClientID = "1", ClientSecret = "2"});
      mObserver.Setup(o => o.AddMessages("authorization url"));
      mHandler.Setup(o => o.GetAuthUrl(It.Is<Credentials>( c => AreEqual(c, new Credentials { ClientID = "1", ClientSecret = "2" })))).Returns("authorization url");
      mCommand.Execute("authorization url");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mStore = Mok<ICredentialStore>();
      mHandler = Mok<IGoulRequestHandler>();
      mCommand = new GetAuthorizationUrlCommand(mObserver.Object, mStore.Object, mHandler.Object);
    }

    private Mock<IMessageObserver> mObserver;
    private Mock<ICredentialStore> mStore;
    private Mock<IGoulRequestHandler> mHandler;
    private ICommand mCommand;
  }
}