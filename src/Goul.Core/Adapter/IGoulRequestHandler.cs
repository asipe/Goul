using System.Collections.Generic;
using Goul.Core.Tokens;

namespace Goul.Core.Adapter {
  public interface IGoulRequestHandler {
    string GetAuthUrl(Credentials credentials);
    string CreateRefreshToken(Credentials credentials, string authCode);
    List<string> GetFilesByTitle(Credentials credentials, RefreshToken refreshToken);
    void UploadFile(string fileToUpload, string fileTitle, Credentials credentials, RefreshToken refreshToken);
    void UploadFileWithFolder(string file, string fileTitle,string[] foldersToUpload, Credentials credentials, RefreshToken refreshToken);
    void DeleteAllFiles(Credentials credentials, RefreshToken refreshToken);
    string GetFolderFromRoot(string folderToGet, Credentials credentials, RefreshToken refreshToken);
    string GetChildOfFolderOnRoot(string folderOnRoot, Credentials credentials, RefreshToken refreshToken);
    string GetFileAtTheLastDirectory(string rootFolder, Credentials credentials, RefreshToken refreshToken);
  }
}