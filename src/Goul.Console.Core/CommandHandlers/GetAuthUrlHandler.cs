// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Goul.Console.Core.Storage;
using Goul.Core;
using SupaCharge.Core.IOAbstractions;

namespace Goul.Console.Core.CommandHandlers {
  public class GetAuthUrlHandler : ICommandHandler {
    public GetAuthUrlHandler(IAuthorizationState state) {
      mState = state;
    }

    public void Execute(params string[] args) {
      mProvider = Constants.GetAppClient(new CredentialsRepository(new DotNetFile(), "credentials.txt").Load());
      System.Console.WriteLine();
      System.Console.WriteLine(GetAuthorization(mProvider));
    }

    private Uri GetAuthorization(UserAgentClient appClient) {
      return appClient.RequestUserAuthorization(mState);
    }

    private NativeApplicationClient mProvider;
    private readonly IAuthorizationState mState;
  }
}