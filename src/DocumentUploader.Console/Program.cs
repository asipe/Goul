using System;
using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;

namespace DocumentUploader.Console {
  internal class Program {
    private static int Main(string[] args) {
      try {
        var app = new Factory(new DefaultModuleConfiguration()).Build<IApp>();
        app.Execute(args);
        return 0;
      } catch (Exception e) {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
        return 1;
      }
    }
  }
}