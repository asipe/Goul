using System;
using Goul.Core;

namespace Goul.Console.Core {
  public class App {
    public App(IGetAuthUrlHandler getAuthUrlHandler, IAuthorizerHandler authHandler, IUploadHandler uploadHandler) {
      mGetAuthUrlHandler = getAuthUrlHandler;
      mAuthHandler = authHandler;
      mUploadHandler = uploadHandler;
    }

    public void Execute(params string[] args) {
      if (args.Length == 0)
        throw new Exception("Unknown Command");

      switch (args[0]) {
        case "getauth":
          System.Console.WriteLine(mGetAuthUrlHandler.GetUrl());
          break;

        case "authorize":
          mAuthHandler.Authorize(args[1]);
          break;

        case "upload":
          mUploadHandler.Upload(args[1], args[2]);
          break;

        default:
          throw new Exception("Unknown Command");
      }
    }

    private readonly IAuthorizerHandler mAuthHandler;
    private readonly IGetAuthUrlHandler mGetAuthUrlHandler;
    private readonly IUploadHandler mUploadHandler;
  }
}