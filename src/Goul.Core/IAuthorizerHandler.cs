namespace Goul.Core {
  public interface IAuthorizerHandler {
    string Authorize(string authCode);
  }
}