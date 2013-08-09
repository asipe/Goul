namespace Goul.Core {
  public class Uploader {
    public void Execute(string fileToUpload, string fileTitle, Credentials credentials, RefreshToken refreshToken) {
      var service = new GetDriveService().GetService(credentials, refreshToken);
    } 
  }
}