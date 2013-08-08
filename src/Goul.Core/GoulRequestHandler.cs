namespace Goul.Core {
  public class GoulRequestHandler : IGoulRequestHandler {
    public string GetAuthUrl(Credentials credentials) {
      var result = GetAuthorizationUrl.GetAuthorization(GetAuthorizationUrl.BuildNativeAppClient(credentials));
      return result.ToString();
    }

    public string CreateRefreshToken(Credentials credentials, string code) {
      return new GetAuthorizationState().GetAuthorization(credentials, code).RefreshToken;
    }
  }
}