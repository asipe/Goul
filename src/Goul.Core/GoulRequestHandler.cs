using System.Collections.Generic;

namespace Goul.Core {
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
      var uploader = new Uploader();
      uploader.Execute(fileToUpload, fileTitle, credentials, refreshToken);
    }

    public void DeleteAllFiles(Credentials credentials, RefreshToken refreshToken) {
      new GDriveFileManager(credentials, refreshToken).CleanGDriveAcct();
    }
  }
}