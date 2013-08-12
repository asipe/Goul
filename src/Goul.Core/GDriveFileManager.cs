using System.Collections.Generic;
using Google.Apis.Drive.v2;

namespace Goul.Core {
  public class GDriveFileManager {
    public GDriveFileManager(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
    }

    public List<string> GetFilesByTitle() {
      var files = mService.Files.List().Fetch().Items;
      var output = new List<string>();
      for (var x = 0; x < files.Count; x++) output.Add(files[x].Title);

      return output;
    }

    public void CleanGDriveAcct() {
      var files = mService.Files.List().Fetch().Items;

      for (var x = 0; x < files.Count; x++) mService.Files.Delete(files[x].Id).Fetch();
    }

    private readonly DriveService mService;
  }
}