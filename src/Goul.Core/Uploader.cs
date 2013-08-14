using System.Collections.Generic;
using System.IO;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Core {
  public class Uploader {
    public Uploader(Credentials credentials, RefreshToken refreshToken) {
      mCredentials = credentials;
      mRefreshToken = refreshToken;
      mService = new GetDriveService().GetService(mCredentials, mRefreshToken);
    }

    public void UploadFile(string fileToUpload, string fileTitle) {
      var file = new File {Title = fileTitle, Description = "123"};
      var stream = new MemoryStream(System.IO.File.ReadAllBytes(fileToUpload));
      var request = mService.Files.Insert(file, stream, "text/plain");
      request.Convert = true;
      request.Upload();
    }

    public void UploadFolderSetWithParents(string[] folders) {
      var parent = new ParentReference {Id = "root"};
      for (var x =0; x< folders.Length; x++) {
        var file = new File {Title = folders[x], MimeType = "application/vnd.google-apps.folder", Parents = new List<ParentReference> {parent}};
        var result = mService.Files.Insert(file).Fetch();
        parent = new ParentReference {Id = result.Id};
      }
    }

    private readonly Credentials mCredentials;
    private readonly RefreshToken mRefreshToken;
    private readonly DriveService mService;
  }
}