using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace Goul.Core {
  public static class Constants {
    public static NativeApplicationClient GetAppClient(Credentials credentials) {
      return new NativeApplicationClient(GoogleAuthenticationServer.Description, credentials.ClientId, credentials.ClientSecret);
    }

    public static string[] GetScopes() {
      return new[] {"https://www.googleapis.com/auth/drive"};
    }
  }
}