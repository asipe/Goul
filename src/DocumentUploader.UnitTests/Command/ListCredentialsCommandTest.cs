using DocumentUploader.Core.Command;
using DocumentUploader.Core.Observer;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests.Command {
  [TestFixture]
  public class ListCredentialsCommandTest : BaseTestCase {
    [Test]
    public void TestThatListDisplays3Values() {
      mObserver.Setup(o => o.AddMessages("1", "2"));
      mFile.Setup(f => f.Exists("credentials.txt")).Returns(true);
      mFile.Setup(f => f.ReadAllLines("credentials.txt")).Returns(new[] {"1", "2"});
      mCommand.Execute("listcredentials");
    }

    [Test]
    public void TestThatListShowsErrorMessageWhenTheFileIsMissing() {
      mObserver.Setup(o => o.AddMessages("Could not find the Credentials file"));
      mFile.Setup(f => f.Exists("credentials.txt")).Returns(false);
      mCommand.Execute("listcredentials");
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IMessageObserver>();
      mFile = Mok<IFile>();
      mCommand = new ListCredentialsCommand(mObserver.Object, mFile.Object);
    }

    private ICommand mCommand;
    private Mock<IFile> mFile;
    private Mock<IMessageObserver> mObserver;
  }
}