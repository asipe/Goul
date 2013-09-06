using System.Collections.Generic;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;

namespace Goul.Core.Functionality {
  public class FileEnumerator {
    public FileEnumerator(DriveService service) {
      mService = service;
    }

    public IList<File> EnumerateAllFiles() {
      return mService.Files.List().Fetch().Items;
    }

    public IList<File> EnumerateFilesWithQuery(string[] qRequests) {
      var request = mService.Files.List();
      var qString = qRequests[0];

      if (qString.Length == 1) {
        request.Q = qString;
        return request.Fetch().Items;
      }

      foreach (var s in qRequests) {
        qString = qString + " and " + s;
        request.Q = qString;
      }
      return request.Fetch().Items;
    }

    private readonly DriveService mService;
  }
}