// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Goul.Console.Core.Storage;
using Goul.Core;
using SupaCharge.Core.IOAbstractions;

namespace Goul.Console.Core.CommandHandlers {
  public class GetAuthorizedState {
    public static IAuthorizationState GetAuthState(NativeApplicationClient provider) {
      var token = new RefreshTokenRepository(new DotNetFile(), "refreshToken.txt").Load()[0];
      var state = new AuthorizationState(
        Constants.GetScopes())
      {Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl), RefreshToken = token};
      provider.RefreshToken(state);
      return state;
    }
  }
}