using Goul.Console.Core;
using Goul.Core;
using NUnit.Framework;

namespace Goul.UnitTests.Console.Core {
  [TestFixture]
  public class ConsoleDisplayTest {
    [Test]
    public void TestGetAuthUrlHandlerReturnsCorrectUrl() {
      Assert.That(mUrlHandler.GetUrl(), Is.EqualTo("this.url"));
    }

    [SetUp]
    public void DoSetup() {
      mUrlHandler = new GetAuthUrlHandler();
    }

    private IGetAuthUrlHandler mUrlHandler;
  }

}