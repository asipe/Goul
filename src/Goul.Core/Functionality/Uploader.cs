using System.Collections.Generic;
using System.IO;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Goul.Core.FileManagement;
using Goul.Core.Tokens;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Core.Functionality {
  public class Uploader {
    public Uploader(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
      mUpdater = new Updater(credentials, refreshToken);
      mManager = new GDriveFileManager(credentials, refreshToken);
    }

    public void UploadFile(string fileToUpload, string fileTitle) {
      // if (mUpdater.IsUpdateRequired(fileTitle))
      //  mUpdater.Update(fileToUpload, mManager.ListAllFilesOnRootById()[0]);
      //   else {
      var file = new File {Title = fileTitle, Description = "123"};
      var stream = new MemoryStream(System.IO.File.ReadAllBytes(fileToUpload));
      var request = mService.Files.Insert(file, stream, DetermineContentType(fileToUpload));
      request.Convert = true;
      request.Upload();
      //    }
    }

    public void UploadFileWithFolderSet(string file, string fileTitle, string[] foldersToUpload) {
      var parent = new ParentReference {Id = "root"};
      foreach (var f in foldersToUpload) {
        int indexThatMatches;
        if (CheckIfFolderExists(f, parent.Id, out indexThatMatches)) {
          var parentFolder = new ParentReference {Id = ReturnMatchingFolder(indexThatMatches, parent.Id).Id};
          parent = new ParentReference {Id = parentFolder.Id};
        } else {
          var lastFolderUploaded = UploadFolderWithParent(parent, f);
          parent = new ParentReference {Id = lastFolderUploaded};
        }
      }
      UploadFileWithParent(parent, file, fileTitle);
    }

    public bool CheckIfFolderExists(string folderTitleToCheckFor, string parentId, out int indexToChange) {
      var children = mService.Children.List(parentId).Fetch().Items;
      for (var x = 0; x < children.Count; x++) {
        var fileToCheck = mService.Files.Get(children[x].Id).Fetch();

        if (fileToCheck.Title == folderTitleToCheckFor && fileToCheck.MimeType == "application/vnd.google-apps.folder") {
          indexToChange = x;
          return true;
        }
      }
      indexToChange = 0;
      return false;
    }

    public File ReturnMatchingFolder(int indexToGet, string parentId) {
      var children = mService.Children.List(parentId).Fetch().Items;
      return mService.Files.Get(children[indexToGet].Id).Fetch();
    }

    public string UploadFolderWithParent(ParentReference parentId, string title) {
      var folder = new File { Title = title, Parents = new List<ParentReference> { parentId }, MimeType = "application/vnd.google-apps.folder" };
      var request = mService.Files.Insert(folder);
      request.Convert = true;
      var result = request.Fetch();

      return result.Id;
    }

    public void UploadFileWithParent(ParentReference parentId, string path, string title) {
      var file = new File { Title = title, Parents = new List<ParentReference> { parentId }, MimeType = DetermineContentType(path) };
      var request = mService.Files.Insert(file);
      request.Convert = true;
      request.Fetch();
    }

    public string DetermineContentType(string filePathToCheck) {
      return Path.GetExtension(filePathToCheck) == ".csv" ? "text/csv" : "text/plain";
    }

    private readonly IFileManager mManager;
    private readonly DriveService mService;
    private readonly Updater mUpdater;

  }
}