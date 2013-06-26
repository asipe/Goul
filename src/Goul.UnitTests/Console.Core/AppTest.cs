using System;
using Goul.Console.Core;
using Goul.Core;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests.Console.Core {
  [TestFixture]
  public class AppTest : BaseTestCase {
    [Test]
    public void TestExecuteWithNoArgThrows() {
      var ex = Assert.Throws<Exception>(() => mApp.Execute());
      Assert.That(ex.Message, Is.EqualTo("Unknown Command"));
    }

    [Test]
    public void TestExecuteWithUnknownCommandThrows() {
      var ex = Assert.Throws<Exception>(() => mApp.Execute("INVALIDCOMMAND", "SOMEARG"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Command"));
    }

    [Test]
    public void TestExecuteGetAuthCommandDelegatestoInterface() {
      var args = new[] {"getauth"};
      mGetAuthHandler.Setup(h => h.GetUrl()).Returns("test");
      mApp.Execute(args);
    }

    [Test]
    public void TestExecuteAuthorizesDelegatesToInterface() {
      var args = new[] {"authorize", "authcode"};
      mAuthorizerHandler.Setup(h => h.Authorize(args[1])).Returns("refreshToken");
      mApp.Execute(args);
    }

    [Test]
    public void TestExecuteUploadDelegatesToInterface() {
      var args = new[] {"upload", "filePath", "newFileName"};
      mUploadHandler.Setup(h => h.Upload("filePath", "newFileName"));
      mApp.Execute(args);
    }

    [SetUp]
    public void DoSetup() {
      mGetAuthHandler = Mok<IGetAuthUrlHandler>();
      mAuthorizerHandler = Mok<IAuthorizerHandler>();
      mUploadHandler = Mok<IUploadHandler>();
      mApp = new App(mGetAuthHandler.Object, mAuthorizerHandler.Object, mUploadHandler.Object);
    }

    private App mApp;
    private Mock<IGetAuthUrlHandler> mGetAuthHandler;
    private Mock<IAuthorizerHandler> mAuthorizerHandler;
    private Mock<IUploadHandler> mUploadHandler;
  }
}