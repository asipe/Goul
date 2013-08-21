using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Drive.v2;
using Goul.Core.Functionality;
using Goul.Core.Tokens;

namespace Goul.Core.FileManagement {
  public class GDriveFileManager : IFileManager {
    public GDriveFileManager(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
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

    public List<string> ListAllFilesOnRootById() {
      var request = mService.Files.List();
      request.Q = "'root' in parents";
      return request.Fetch().Items.Select(t => t.Id).ToList();
    }

    public List<string> ListAllFilesOnRootByTitle() {
      var request = mService.Files.List();
      request.Q = "'root' in parents";
      return request.Fetch().Items.Select(t => t.Id).ToList();
    }

    public string GetChildOfFolderOnRoot(string folderOnRootToRetrieve) {
      var request = mService.Children.List(GetFolderIdFromRoot(folderOnRootToRetrieve));
      return request.Fetch().Items[0].Id;
    }

    public string GetFileAtTheLastDirectory(string rootFolder) {
      var folder = GetFolderIdFromRoot(rootFolder);
      var children = mService.Children.List(folder).Fetch();
      var file = mService.Files.Get(children.Items[0].Id);

      while (file.Fetch().MimeType == "application/vnd.google-apps.folder") {
        folder = children.Items[0].Id;
        children = mService.Children.List(folder).Fetch();
        file = mService.Files.Get(children.Items[0].Id);
      }

      return file.Fetch().Id;
    }

    private readonly DriveService mService;
  }
}