using Google.Apis.Drive.v2;
using Goul.Core.FileManagement;
using Goul.Core.Tokens;

namespace Goul.Core.Functionality {
  public class Updater {
    public Updater(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
      mManager = new GDriveFileManager(credentials, refreshToken);
    }

    public bool IsUpdateRequired(string fileTitleToCheckAgaisnt) {
      return mManager.ListAllFilesOnRootByTitle().Contains(fileTitleToCheckAgaisnt);
    }

    public void Update(string filePath, string fileUpdateId) {
      var file = mService.Files.Get(fileUpdateId).Fetch();
      var byteArray = System.IO.File.ReadAllBytes(filePath);
      var stream = new System.IO.MemoryStream(byteArray);
      //only handling plain text
      mService.Files.Update(file, fileUpdateId, stream, "text/plain").Upload();

    }

    private readonly IFileManager mManager;
    private DriveService mService;
  }
}