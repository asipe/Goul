using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace Goul.Core {
  public class AuthorizerHandler : IAuthorizerHandler {
    public string Authorize(string code) {
      var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description, "672441525251.apps.googleusercontent.com", "qqMMwnGP_w29U-Mr5mzAEaGu");
      return GetAuthorization(provider, code);
    }

    private string GetAuthorization(NativeApplicationClient appClient, string code) {
      var tokenHandler = new RefreshTokenHandler();

      var state = new AuthorizationState(new[] {"https://www.googleapis.com/auth/drive", "https://spreadsheets.google.com/feeds", "https://docs.google.com/feeds"});
      state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
      var result = appClient.ProcessUserAuthorization(code, state);
      tokenHandler.Update(state.RefreshToken);
      return state.RefreshToken;
    }
  }
}