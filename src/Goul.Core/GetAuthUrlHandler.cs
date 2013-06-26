using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace Goul.Core {
  public class GetAuthUrlHandler : IGetAuthUrlHandler {
    public GetAuthUrlHandler(NativeApplicationClient provider, IAuthorizationState state) {
      mProvider = provider;
      mState = state;
    }

    public string GetUrl() {
      return GetAuthorization(mProvider).ToString();
    }

    private Uri GetAuthorization(UserAgentClient appClient) {
      return appClient.RequestUserAuthorization(mState);
    }

    private readonly NativeApplicationClient mProvider;
    private readonly IAuthorizationState mState;
  }
}