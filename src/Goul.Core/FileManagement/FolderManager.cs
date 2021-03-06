﻿using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Goul.Core.Functionality;
using Goul.Core.Tokens;

namespace Goul.Core.FileManagement {
  public class FolderManager : IFolderManager {
    public FolderManager(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
    }

    public void SetupFolders(int numberOfFolders) {
      var parent = new ParentReference {Id = "root"};
      for (var x = 0; x < numberOfFolders; x++) {
        var folder = new File {MimeType = "application/vnd.google-apps.folder", Title = "TestingFolder" + x, Parents = new[] {parent}};
        var result = mService.Files.Insert(folder).Fetch();
        parent = new ParentReference {Id = result.Id};
      }
    }

    private readonly DriveService mService;
  }
}