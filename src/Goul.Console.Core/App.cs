using System;

namespace Goul.Console.Core {
  public class App {
    public App(ICommandHandler getAuthUrlHandler, ICommandHandler authHandler, ICommandHandler uploadHandler) {
      mGetAuthUrlHandler = getAuthUrlHandler;
      mAuthHandler = authHandler;
      mUploadHandler = uploadHandler;
    }

    public void RunCommand(params string[] args) {
      if (args.Length == 0)
        throw new Exception("Unknown Command");

      switch (args[0]) {
        case "getauth":
          mGetAuthUrlHandler.Execute();
          break;

        case "authorize":
          mAuthHandler.Execute(args[1]);
          break;

        case "upload":
          mUploadHandler.Execute(new[] { args[1], args[2] });
          break;

        default:
          throw new Exception("Unknown Command");
      }
    }

    private readonly ICommandHandler mAuthHandler;
    private readonly ICommandHandler mGetAuthUrlHandler;
    private readonly ICommandHandler mUploadHandler;
  }
}