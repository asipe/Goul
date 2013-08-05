using DocumentUploader.Core.Command;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class GetAuthorizationUrlCommandTest : BaseTestCase {
    [Test]
    public void TestGetAuthUrlCommandWorks() {
      mCredentialStore.Setup(o => o.Get()).Returns(mCredentials.Object);
      mObserver.Setup(o => o.AddMessages("authorization url"));
      mGoulReqHandler.Setup(o => o.GetAuthUrl(mCredentials.Object)).Returns("authorization url");
      mGetAuthUrlCmd.Execute("authorization url");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mCredentialStore = Mok<ICredentialStore>();
      mGoulReqHandler = Mok<IGoulRequestHandler>();
      mCredentials = Mok<Credentials>();
      mGetAuthUrlCmd = new GetAuthorizationUrlCommand(mObserver.Object, mCredentialStore.Object, mGoulReqHandler.Object);
    }

    private Mock<IMessageObserver> mObserver;
    private Mock<ICredentialStore> mCredentialStore;
    private Mock<IGoulRequestHandler> mGoulReqHandler;
    private Mock<Credentials> mCredentials;
    private ICommand mGetAuthUrlCmd;
  }
}