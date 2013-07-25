using Google.Apis.Drive.v2;
using Goul.Console.Core.CommandHandlers;

namespace Goul.Console.Core {
  public class GDriveIdRetrieval {
    public GDriveIdRetrieval() {
      mService = GetDriveService.GetService();
    }
    public string GetFileID(string fileToLookFor) {
      var request = mService.Files.List();
      request.Q = string.Format("mimeType != 'application/vnd.google-apps.folder' and 'root' in parents and title contains '{0}'", fileToLookFor);
      var result = request.Fetch().Items;
     return result[0].Id;
    }

    private DriveService mService;

    public string[] GetMultipleFileIDs(string doNotDelete) {
      throw new System.NotImplementedException();
    }
  }
}
