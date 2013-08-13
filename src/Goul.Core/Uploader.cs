using System.IO;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Core {
  public class Uploader {
    public void UploadFile(string fileToUpload, string fileTitle, Credentials credentials, RefreshToken refreshToken) {
      var service = new GetDriveService().GetService(credentials, refreshToken);
      var file = new File {Title = fileTitle, Description = "123"};
      var stream = new MemoryStream(System.IO.File.ReadAllBytes(fileToUpload));
      var request = service.Files.Insert(file, stream, "text/plain");
      request.Convert = true;
      request.Upload();
    }

    public void UploadFolderSetWithParents(string[] folders, Credentials credentials, RefreshToken refreshToken) {
      var service = new GetDriveService().GetService(credentials, refreshToken);
      var parent = "root";
      for (var x =0; x< folders.Length; x++) {
        var file = new File { Title = folders[x], MimeType = "application/vnd.google-apps.folder" };
        service.Files.Insert(file).Fetch();
        //file.Id = parent;
      }
    }
  }
}