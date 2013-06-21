using Goul.Console.Core;

namespace Goul.Console {
  internal class Program {
    private static void Main(string[] args) {
      //TODO: wrap in a try catch and return correct error code for success or failure
      //TODO: on exceptions print out the exception details to console.writeline
      new App(null).Execute(args);
    }
  }
}