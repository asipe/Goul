// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace Goul.Console.Core.CommandHandlers {
  public class GetAuthUrlHandler : ICommandHandler {
    public GetAuthUrlHandler(NativeApplicationClient provider, IAuthorizationState state) {
      mProvider = provider;
      mState = state;
    }

    public void Execute(params string[] args) {
      System.Console.WriteLine(GetAuthorization(mProvider));
    }

    private Uri GetAuthorization(UserAgentClient appClient) {
      return appClient.RequestUserAuthorization(mState);
    }

    private readonly NativeApplicationClient mProvider;
    private readonly IAuthorizationState mState;
  }
}