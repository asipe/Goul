using System;
using Goul.Console.Core;

namespace Goul.Console {
  internal class Program {
    private static int Main(string[] args) {
      //TODO: wrap in a try catch and return correct error code for success or failure
      //TODO: on exceptions print out the exception details to console.writeline
      try {
        new App(null, null, null).Execute(args);
        return 0;
      } catch (Exception e) {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
        return 1;
      }
    }
  }
}