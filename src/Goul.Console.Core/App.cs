// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using Goul.Console.Core.CommandHandlers;

namespace Goul.Console.Core {
  public class App {
    public App(ICommandHandler getAuthUrlHandler, ICommandHandler authHandler, ICommandHandler uploadHandler, ICommandHandler setCredentialsHandler) {
      mGetAuthUrlHandler = getAuthUrlHandler;
      mAuthHandler = authHandler;
      mUploadHandler = uploadHandler;
      mSetCredentialsHandler = setCredentialsHandler;
    }

    public void RunCommand(params string[] args) {
      if (args.Length == 0)
        throw new Exception("Unknown Command");

      switch (args[0]) {
        case "getauthorizationurl":
          mGetAuthUrlHandler.Execute();
          break;

        case "authorize":
          mAuthHandler.Execute(args[1]);
          break;

        case "upload":
          mUploadHandler.Execute(new[] {args[1], args[2]});
          break;

        case "setcredentials":
          mSetCredentialsHandler.Execute(new[] {args[1], args[2]});
          break;

        default:
          throw new Exception("Unknown Command");
      }
    }

    private readonly ICommandHandler mAuthHandler;
    private readonly ICommandHandler mGetAuthUrlHandler;
    private readonly ICommandHandler mSetCredentialsHandler;
    private readonly ICommandHandler mUploadHandler;
  }
}