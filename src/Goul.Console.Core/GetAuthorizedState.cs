using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace Goul.Console.Core {
  public class GetAuthorizedState {
    public static IAuthorizationState GetAuthState(NativeApplicationClient provider) {
      var refreshToken = new RefreshTokenHandler().GetRefreshToken();
      var state = new AuthorizationState(new[] {"https://www.googleapis.com/auth/drive", "https://docs.google.com/feeds"});
      state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
      state.RefreshToken = refreshToken;
      provider.RefreshToken(state);
      return state;
    }
  }
}