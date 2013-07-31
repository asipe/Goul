using DocumentUploader.Core;
using DocumentUploader.Core.App;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class AppTest:BaseTestCase {
    [Test]
    public void TestExecuteWithProperValueRunsTheCommand() {
      var commands = new[] {"help"};
      mCommand.Setup(c => c.Execute(commands));
      mApp.Execute(commands);
    }

    [Test]
    public void TestExecuteWithInvalidValueDoesnotExecuteTheCommand() {
      var commands = new[] { "randomCmd" };
      mApp.Execute(commands);
    }

    [SetUp]
    public void DoSetup() {
      mCommand = Mok<ICommand>();
      mApp = new App(mCommand.Object);
    }

    private App mApp;
    private Mock<ICommand> mCommand;
  }
}