using System.Collections.Generic;
using System.Linq;
using Google.Apis.Drive.v2;
using Goul.Core.Functionality;
using Goul.Core.Tokens;

namespace Goul.Core.FileManagement {
  public class GDriveFileManager : IFileManager {
    public GDriveFileManager(Credentials credentials, RefreshToken refreshToken) {
      mService = new GetDriveService().GetService(credentials, refreshToken);
      mFileEnum = new FileEnumerator(mService);
    }

    public void CleanGDriveAcct() {
      var files = mFileEnum.EnumerateAllFiles();

      foreach (var f in files)
        mService.Files.Delete(f.Id).Fetch();
    }

    public string GetFolderIdFromRoot(string folderTitleToLookFor) {
      return mFileEnum.EnumerateFilesWithQuery(new[] {"mimeType = 'application/vnd.google-apps.folder'", string.Format("title='{0}'", folderTitleToLookFor)})[0].Id;
    }

    public List<string> ListAllFilesOnRootById() {
      return mFileEnum.EnumerateFilesWithQuery(new[] {"'root' in parents"}).Select(t => t.Id).ToList();
    }

    public List<string> ListAllFilesOnRootByTitle() {
      return mFileEnum.EnumerateFilesWithQuery(new[] {"'root' in parents"}).Select(t => t.Title).ToList();
    }

    public List<string> ListAllFoldersOnRootById() {
      return mFileEnum.EnumerateFilesWithQuery(new[] {"'root' in parents", "mimeType = 'application/vnd.google-apps.folder'"}).Select(t => t.Title).ToList();
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

    public string GetFileMimeType(string id) {
      return mService.Files.Get(id).Fetch().MimeType;
    }

    private readonly FileEnumerator mFileEnum;
    private readonly DriveService mService;
  }
}