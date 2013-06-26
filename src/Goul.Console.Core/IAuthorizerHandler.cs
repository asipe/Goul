namespace Goul.Console.Core {
  public interface IAuthorizerHandler {
    string Authorize(string authCode);
  }
}