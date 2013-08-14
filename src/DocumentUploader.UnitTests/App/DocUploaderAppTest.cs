using Autofac.Features.Indexed;
using DocumentUploader.Core.App;
using DocumentUploader.Core.Command;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests.App {
  [TestFixture]
  public class DocUploaderAppTest : BaseTestCase {
    private class StubIndex : IIndex<string, ICommand> {
      public ICommand NextCommandToReturn{private get;set;}
      public string NextExpectedKey{private get;set;}

      public bool TryGetValue(string key, out ICommand value) {
        value = NextCommandToReturn;
        Assert.That(key, Is.EqualTo(NextExpectedKey));
        return value != null;
      }

      public ICommand this[string key] {
        get {return null;}
      }
    }

    [Test]
    public void TestExecuteWithProperValueRunsTheCommand() {
      mIndex.NextCommandToReturn = mCommand.Object;
      mIndex.NextExpectedKey = "help";
      mCommand.Setup(c => c.Execute("help"));
      mApp.Execute("help");
    }

    [Test]
    public void TestExecuteWithInvalidValueDoesnotExecuteTheCommand() {
      mIndex.NextExpectedKey = "unknown_command";
      mApp.Execute("unknown_command");
    }

    [SetUp]
    public void DoSetup() {
      mIndex = new StubIndex();
      mCommand = Mok<ICommand>();
      mApp = new DocUploaderApp(mIndex);
    }

    private DocUploaderApp mApp;
    private Mock<ICommand> mCommand;
    private StubIndex mIndex;
  }
}