using System;

namespace Goul.Console.Core {
  public class App {
    public App(IGenerateAuthorizationHandler generateAuthorizationHandler) {
      mGenerateAuthorizationHandler = generateAuthorizationHandler;
    }

    public void Execute(params string[] args) {
      if (args.Length == 0)
        throw new Exception("Unknown Command");

      //reaplace with a switch with default throwing
      if (args[0] == "genauth")
        mGenerateAuthorizationHandler.Execute();
      else
        throw new Exception("Unknown Command");
    }

    private readonly IGenerateAuthorizationHandler mGenerateAuthorizationHandler;
  }
}