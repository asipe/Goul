using DocumentUploader.Core.Command;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core.Adapter;
using Goul.Core.Tokens;
using Moq;
using NUnit.Framework;

namespace DocumentUploader.UnitTests.Command {
  [TestFixture]
  public class GetAuthorizationUrlCommandTest : DocumentUploaderBaseTestCase {
    [Test]
    public void TestGetAuthUrlCommandWorks() {
      var credentials = CA<Credentials>();
      mStore.Setup(o => o.Get()).Returns(credentials);
      mObserver.Setup(o => o.AddMessages("authorization url"));
      mHandler.Setup(o => o.GetAuthUrl(It.Is<Credentials>(c => AreEqual(c, credentials)))).Returns("authorization url");
      mCommand.Execute();
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