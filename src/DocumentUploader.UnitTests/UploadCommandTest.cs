using DocumentUploader.Core.Command;
using DocumentUploader.Core.Observer;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class UploadCommandTest : BaseTestCase {
    [Test]
    public void TestUploadMessageIsSent() {
      mObserver.Setup(o => o.AddMessages("File uploaded"));
      mCommand.Execute("upload");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mCommand = new UploadCommand(mObserver.Object);
    }

    private Mock<IMessageObserver> mObserver;
    private ICommand mCommand;
  }
}