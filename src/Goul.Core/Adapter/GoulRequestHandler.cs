﻿using Goul.Core.Functionality;
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

    public void UploadFileWithFolder(string file, string fileTitle, string[] foldersToUpload, Credentials credentials, RefreshToken refreshToken) {
      var uploader = new Uploader(credentials, refreshToken);
      uploader.UploadFileWithFolderSet(file, fileTitle, foldersToUpload);
    }
  }
}