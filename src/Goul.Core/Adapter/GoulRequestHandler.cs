using System.Collections.Generic;
using Goul.Core.Functionality;
using Goul.Core.ITHelper;
using Goul.Core.Tokens;

namespace Goul.Core.Adapter {
  public class GoulRequestHandler : IGoulRequestHandler {
    public string GetAuthUrl(Credentials credentials) {
      var result = GetAuthorizationUrl.GetAuthorization(GetAuthorizationUrl.BuildNativeAppClient(credentials));
      return result.ToString();
    }

    public string CreateRefreshToken(Credentials credentials, string code) {
      return new GetAuthorizationState().GetAuthorization(credentials, code).RefreshToken;
    }

    public List<string> GetFilesByTitle(Credentials credentials, RefreshToken refreshToken) {
      return new GDriveFileManager(credentials, refreshToken).GetFilesByTitle();
    }

    public void UploadFile(string fileToUpload, string fileTitle, Credentials credentials, RefreshToken refreshToken) {
      var uploader = new Uploader(credentials, refreshToken);
      uploader.UploadFile(fileToUpload, fileTitle);
    }

    public void UploadFileWithFolder(string file, string fileTitle, string[] foldersToUpload, Credentials credentials, RefreshToken refreshToken) {
      var uploader = new Uploader(credentials, refreshToken);
      // uploader.UploadFolderSetWithParents(foldersToUpload);
      uploader.UploadFileWithFolderSet(file, fileTitle, foldersToUpload);
    }

    public void DeleteAllFiles(Credentials credentials, RefreshToken refreshToken) {
      var manager = new GDriveFileManager(credentials, refreshToken);
      manager.CleanGDriveAcct();
    }

    public string GetFolderFromRoot(string folderToGet, Credentials credentials, RefreshToken refreshToken) {
      var manager = new GDriveFileManager(credentials, refreshToken);
      return manager.GetFolderIdFromRoot(folderToGet);
    }

    public string GetChildOfFolderOnRoot(string folderOnRoot, Credentials credentials, RefreshToken refreshToken) {
      var manager = new GDriveFileManager(credentials, refreshToken);
      return manager.GetChildOfFolderOnRoot(folderOnRoot);
    }

    public string GetFileAtTheLastDirectory(string rootFolder, Credentials credentials, RefreshToken refreshToken) {
      var manager = new GDriveFileManager(credentials, refreshToken);
      return manager.GetFileAtTheLastDirectory(rootFolder);
    }
  }
}