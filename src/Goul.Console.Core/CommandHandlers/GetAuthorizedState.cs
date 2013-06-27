using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Goul.Console.Core.Storage;
using SupaCharge.Core.IOAbstractions;

namespace Goul.Console.Core.CommandHandlers {
  public class GetAuthorizedState {
    public static IAuthorizationState GetAuthState(NativeApplicationClient provider) {
      var token = new RefreshTokenRepository(new DotNetFile(), "refreshToken.txt").Load()[0];
      var state = new AuthorizationState(new[] {"https://www.googleapis.com/auth/drive", "https://docs.google.com/feeds"});
      state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
      state.RefreshToken = token;
      provider.RefreshToken(state);
      return state;
    }
  }
}