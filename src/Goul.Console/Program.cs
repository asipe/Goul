using System;
using Goul.Console.Core;
using Goul.Core;

namespace Goul.Console {
  internal class Program {
    private static int Main(string[] args) {
      try {
        new App(new GetAuthUrlHandler(), null, null).Execute(args);
        return 0;
      } catch (Exception e) {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
        return 1;
      }
    }
  }
}