using Goul.Core.Tokens;

namespace Goul.Core.Adapter {
  public interface IGoulRequestHandler {
    string GetAuthUrl(Credentials credentials);
    string CreateRefreshToken(Credentials credentials, string authCode);
    void UploadFileWithFolder(string file, string fileTitle, string[] foldersToUpload, Credentials credentials, RefreshToken refreshToken);
  }
}