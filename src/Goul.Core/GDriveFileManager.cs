using System.Collections.Generic;
using System.Linq;
using Google.Apis.Drive.v2;

namespace Goul.Core {
  public class GDriveFileManager {
    public GDriveFileManager(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
    }

    public List<string> GetFilesByTitle() {
      var files = mService.Files.List().Fetch().Items;
      return files.Select(t => t.Title).ToList();
    }

    public void CleanGDriveAcct() {
      var files = mService.Files.List().Fetch().Items;

      foreach (var f in files)
        mService.Files.Delete(f.Id).Fetch();
    }

    private readonly DriveService mService;
  }
}