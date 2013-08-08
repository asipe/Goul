using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace Goul.Core {
  public class GetAuthorizationState {
    public IAuthorizationState GetAuthorization(Credentials credentials, string authCode) {
      var state = GetState();
      var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description, credentials.ClientID, credentials.ClientSecret);
      provider.ProcessUserAuthorization(authCode, state);
      return state;
    }

    private static IAuthorizationState GetState() {
      var state = new AuthorizationState(new[] { "https://www.googleapis.com/auth/drive" }) { Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl) };
      return state;
    }
  }
}