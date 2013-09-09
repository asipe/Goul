using System.Collections.Generic;
using System.IO;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Goul.Core.Tokens;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Core.Functionality {
  public class Uploader {
    private class FolderQuery {
      public bool Exists{get;set;}
      public int Index{get;set;}
    }

    public Uploader(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
    }

    public void UploadFileWithFolderSet(string file, string fileTitle, string[] foldersToUpload) {
      var parent = new ParentReference {Id = "root"};
      foreach (var f in foldersToUpload) {
        var folderQueryResult = SearchForFolder(f, parent.Id);
        if (folderQueryResult.Exists) {
          var parentFolder = new ParentReference {Id = ReturnMatchingFolder(folderQueryResult.Index, parent.Id).Id};
          parent = new ParentReference {Id = parentFolder.Id};
        } else {
          var lastFolderUploaded = UploadFolderWithParent(parent, f);
          parent = new ParentReference {Id = lastFolderUploaded};
        }
      }
      UploadFileWithParent(parent, file, fileTitle);
    }

    public string UploadFolderWithParent(ParentReference parentId, string title) {
      var folder = new File {Title = title, Parents = new List<ParentReference> {parentId}, MimeType = "application/vnd.google-apps.folder"};
      var request = mService.Files.Insert(folder);
      request.Convert = true;
      var result = request.Fetch();

      return result.Id;
    }

    public void UploadFileWithParent(ParentReference parentId, string path, string title) {
      var file = new File {Title = title, Parents = new List<ParentReference> {parentId}, MimeType = DetermineContentType(path)};
      var byteArray = System.IO.File.ReadAllBytes(path);
      var stream = new MemoryStream(byteArray);

      var request = mService.Files.Insert(file, stream , DetermineContentType(path));
      request.Convert = true;
      request.Upload();
    }

    public string DetermineContentType(string filePathToCheck) {
      return Path.GetExtension(filePathToCheck) == ".csv" ? "text/csv" : "text/plain";
    }

    private FolderQuery SearchForFolder(string folderTitleToCheckFor, string parentId) {
      var children = mService.Children.List(parentId).Fetch().Items;
      for (var x = 0; x < children.Count; x++) {
        var fileToCheck = mService.Files.Get(children[x].Id).Fetch();

        if (fileToCheck.Title == folderTitleToCheckFor && fileToCheck.MimeType == "application/vnd.google-apps.folder")
          return new FolderQuery { Exists = true, Index = x };
      }
      return new FolderQuery { Exists = false, Index = 0 };
    }

    public File ReturnMatchingFolder(int indexToGet, string parentId) {
      var children = mService.Children.List(parentId).Fetch().Items;
      return mService.Files.Get(children[indexToGet].Id).Fetch();
    }

    private readonly DriveService mService;
  }
}