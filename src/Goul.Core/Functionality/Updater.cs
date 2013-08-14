using Google.Apis.Drive.v2;
using Goul.Core.Tokens;

namespace Goul.Core.Functionality {
  public class Updater {
    public Updater(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
    }

    private DriveService mService;
  }