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
      if (args.Length == 0) {
        throw new Exception("Unknown Command");
      }

      switch (args[0]) {
        case "getauth":
          mGetAuthUrlHandler.GetUrl();
          break;
        
        case "authorize":
          mAuthHandler.Authorize();
          break;

        case "upload":
          mUploadHandler.Upload();
          break;

        default:
          throw new Exception("Unknown Command");
      }
    }

    private readonly IGetAuthUrlHandler mGetAuthUrlHandler;
    private readonly IAuthorizerHandler mAuthHandler;
    private readonly IUploadHandler mUploadHandler;
  }
}