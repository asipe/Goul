using System;
using Goul.Console.Core;

namespace Goul.Console {
  internal class Program {
    private static int Main(string[] args) {
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