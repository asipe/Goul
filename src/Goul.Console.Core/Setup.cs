// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Goul.Console.Core.CommandHandlers;
using Goul.Core;

namespace Goul.Console.Core {
  public class Setup {
    public ICommandHandler SetupGetAuthUrl() {
      return new GetAuthUrlHandler(GetProvider(), GetState());
    }

    public ICommandHandler SetupAuthorizerHandler() {
      return new AuthorizerHandler();
    }

    public ICommandHandler SetupUploadHandler() {
      return new UploaderHandler(GetProvider());
    }

    public void setAuthState(IAuthorizationState auth) {
      mAuthState = auth;
    }

    public void SetAuthenticator(OAuth2Authenticator<NativeApplicationClient> authenticator) {
      mAuth = authenticator;
    }

    private IAuthorizationState GetState() {
      var state = new AuthorizationState(Constants.GetScopes());
      state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
      return state;
    }

    private NativeApplicationClient GetProvider() {
      //return new NativeApplicationClient(GoogleAuthenticationServer.Description, "", "");
      return Constants.GetAppClient();
    }

    private OAuth2Authenticator<NativeApplicationClient> mAuth;
    private IAuthorizationState mAuthState;
  }
}