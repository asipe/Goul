using Google.Apis.Drive.v2;
using Goul.Core.ITHelper;
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

    public void Update() {}
    private readonly IFileManager mManager;
    private DriveService mService;
  }
}