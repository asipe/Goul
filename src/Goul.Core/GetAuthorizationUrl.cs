using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace Goul.Core {
  public static class GetAuthorizationUrl {
    public static NativeApplicationClient BuildNativeAppClient(Credentials credentials) {
      return new NativeApplicationClient(GoogleAuthenticationServer.Description, credentials.ClientID, credentials.ClientSecret);
    }

    public static Uri GetAuthorization(UserAgentClient appClient) {
      return appClient.RequestUserAuthorization(GetState());
    }

    private static IAuthorizationState GetState() {
      var state = new AuthorizationState(new[] {"https://www.googleapis.com/auth/drive"}) {Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl)};
      return state;
    }
  }
}