using Goul.Console.Core;

namespace Goul.Console {
  internal class Program {
    private static void Main(string[] args) {
      var app = new ConsoleCommandParser();
      app.Parse(args);
    }
  }
}