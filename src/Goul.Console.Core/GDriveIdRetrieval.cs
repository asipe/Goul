using Google.Apis.Drive.v2;
using Goul.Console.Core.CommandHandlers;
using Goul.Core;

namespace Goul.Console.Core {
  public class GDriveIdRetrieval:IRetrieval {
    public GDriveIdRetrieval() {
      mService = GetDriveService.GetService();
    }
    public string GetFileId(string fileToLookFor) {
      var request = mService.Files.List();
      request.Q = string.Format("mimeType != 'application/vnd.google-apps.folder' and 'root' in parents and title = '{0}'", fileToLookFor);
      var result = request.Fetch().Items;
      return result[0].Id;
    }

    private readonly DriveService mService;
  }
}
