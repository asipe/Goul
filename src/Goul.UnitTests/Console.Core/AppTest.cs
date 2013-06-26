using System;
using Goul.Console.Core;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests.Console.Core {
  [TestFixture]
  public class AppTest : BaseTestCase {
    [Test]
    public void TestExecuteWithNoArgThrows() {
      var ex = Assert.Throws<Exception>(() => mApp.RunCommand());
      Assert.That(ex.Message, Is.EqualTo("Unknown Command"));
    }

    [Test]
    public void TestExecuteWithUnknownCommandThrows() {
      var ex = Assert.Throws<Exception>(() => mApp.RunCommand("INVALIDCOMMAND", "SOMEARG"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Command"));
    }

    [Test]
    public void TestExecuteGetAuthCommandDelegatestoInterface() {
      var args = new[] {"getauth"};
      mGetAuthHandler.Setup(h => h.Execute());
      mApp.RunCommand(args);
    }

    [Test]
    public void TestExecuteAuthorizesDelegatesToInterface() {
      var args = new[] {"authorize", "authcode"};
      mAuthorizerHandler.Setup(h => h.Execute(args[1]));
      mApp.RunCommand(args);
    }

    [Test]
    public void TestExecuteUploadDelegatesToInterface() {
      var args = new[] {"upload", "filePath", "newFileName"};
      var cmdArgs = new[] { "filePath", "newFileName" };
      mUploadHandler.Setup(h => h.Execute(cmdArgs));
      mApp.RunCommand(args);
    }

    [SetUp]
    public void DoSetup() {
      mGetAuthHandler = Mok<ICommandHandler>();
      mAuthorizerHandler = Mok<ICommandHandler>();
      mUploadHandler = Mok<ICommandHandler>();
      mApp = new App(mGetAuthHandler.Object, mAuthorizerHandler.Object, mUploadHandler.Object);
    }

    private App mApp;
    private Mock<ICommandHandler> mGetAuthHandler;
    private Mock<ICommandHandler> mAuthorizerHandler;
    private Mock<ICommandHandler> mUploadHandler;
  }
}