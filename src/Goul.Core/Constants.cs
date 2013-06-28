using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace Goul.Core {
  public static class Constants {
    public static NativeApplicationClient GetAppClient() {
      return new NativeApplicationClient(GoogleAuthenticationServer.Description, "672441525251.apps.googleusercontent.com", "UP0kFyrm59Fa5cx6QJWhEzUk");
    }

    public static string[] GetScopes() {
      return new[] {"https://www.googleapis.com/auth/drive", "https://docs.google.com/feeds"};
    }
  }
}