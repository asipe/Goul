// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Goul.Console.Core.Storage;
using Goul.Core;
using SupaCharge.Core.IOAbstractions;

namespace Goul.Console.Core.CommandHandlers {
  public class AuthorizerHandler : ICommandHandler {
    public void Execute(params string[] args) {
      var provider = Constants.GetAppClient(new Setup().GetCredentialsRepository().Load());
      GetAuthorization(provider, args[0]);
      System.Console.WriteLine("Access Authorized and Refresh Token Created");
    }

    private static void GetAuthorization(NativeApplicationClient appClient, string code) {
      var tokenRepository = new RefreshTokenRepository(new DotNetFile(), "refreshToken.txt");
      var state = new AuthorizationState(Constants.GetScopes())
      {Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl)};

      appClient.ProcessUserAuthorization(code, state);
      tokenRepository.Update(state.RefreshToken);
    }
  }
}