using System;
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

    public string GetFolderIdFromRoot(string folderTitleToLookFor) {
      var request = mService.Files.List();
      request.Q = String.Format("mimeType = 'application/vnd.google-apps.folder' and title='{0}'", folderTitleToLookFor);
      return request.Fetch().Items[0].Id;
    }

    private readonly DriveService mService;
  }
}