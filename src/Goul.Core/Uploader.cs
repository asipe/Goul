using System.IO;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Core {
  public class Uploader {
    public void Execute(string fileToUpload, string fileTitle, Credentials credentials, RefreshToken refreshToken) {
      var service = new GetDriveService().GetService(credentials, refreshToken);
      var file = new File {Title = fileTitle, Description = "123"};
      var stream = new MemoryStream(System.IO.File.ReadAllBytes(fileToUpload));
      var request = service.Files.Insert(file, stream, "text/plain");
      request.Convert = true;
      request.Upload();
    }
  }
}