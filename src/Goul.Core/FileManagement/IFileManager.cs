using System.Collections.Generic;

namespace Goul.Core.FileManagement {
  public interface IFileManager {
    void CleanGDriveAcct();
    string GetFolderIdFromRoot(string folderTitleToLookFor);
    string GetChildOfFolderOnRoot(string folderOnRootToRetrieve);
    string GetFileAtTheLastDirectory(string rootFolder);
    List<string> ListAllFilesOnRootById();
    List<string> ListAllFilesOnRootByTitle();
    string GetFileMimeType(string id);
  }
}