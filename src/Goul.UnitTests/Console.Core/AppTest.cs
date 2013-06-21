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
      var ex = Assert.Throws<Exception>(() => mApp.Execute());
      Assert.That(ex.Message, Is.EqualTo("Unknown Command"));
    }

    [Test]
    public void TestExecuteWithUnknownCommandThrows() {
      var ex = Assert.Throws<Exception>(() => mApp.Execute("INVALIDCOMMAND", "SOMEARG"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Command"));
    }

    [Test]
    public void TestExecuteAuthCommandDelegatestoInterface() {
      var args = new [] {"genauth"};
      mAuthHandler.Setup(h => h.Execute());
      mApp.Execute(args);
    }

    [SetUp]
    public void DoSetup() {
      mAuthHandler = Mok<IGenerateAuthorizationHandler>();
      mApp = new App(mAuthHandler.Object);
    }

    private App mApp;
    private Mock<IGenerateAuthorizationHandler> mAuthHandler;
  }
}