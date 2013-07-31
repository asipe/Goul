using System;
using DocumentUploader.Core;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;

namespace DocumentUploader.Console {
  class Program {
    static int Main(string[] args) {
      try {
        var factory = new Factory(new DefaultModuleConfiguration());
        var app = factory.Build<IApp>();
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
