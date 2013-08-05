namespace Goul.Core {
  public class GoulRequestHandler : IGoulRequestHandler {
    public string GetAuthUrl(Credentials credentials) {
      var result = GetAuthorizationUrl.GetAuthorization(GetAuthorizationUrl.BuildNativeAppClient(credentials));
      return result.ToString();
    }
  }
}