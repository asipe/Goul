using System.Collections.Generic;

namespace Goul.Core {
  public interface IGoulRequestHandler {
    string GetAuthUrl(Credentials credentials);
    string CreateRefreshToken(Credentials credentials, string authCode);
    List<string> GetFilesByTitle(Credentials credentials, RefreshToken refreshToken);
    void UploadFile(string fileToUpload, string fileTitle, Credentials credentials, RefreshToken refreshToken);
    void DeleteAllFiles(Credentials credentials, RefreshToken refreshToken);
  }
}