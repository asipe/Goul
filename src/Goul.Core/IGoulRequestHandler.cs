namespace Goul.Core {
  public interface IGoulRequestHandler {
    string GetAuthUrl(Credentials credentials);
  }
}