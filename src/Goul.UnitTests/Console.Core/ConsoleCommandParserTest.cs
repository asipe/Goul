using System;
using Goul.Console.Core;
using NUnit.Framework;

namespace Goul.UnitTests.Console.Core {
  [TestFixture]
  public class ConsoleCommandParserTest {
    [Test]
    public void TestParserThrowsWhenGivenWrongCommands() {
      Assert.Throws<ArgumentException>(() => mParser.Parse(new[] {"fakeArg"}));
    }

    [SetUp]
    public void DoSetup() {
      mParser = new ConsoleCommandParser();
    }

    private ConsoleCommandParser mParser;
  }
}
