using System.Collections.Generic;

namespace Goul.Core.ITHelper {
  public interface IFileManager {
    List<string> GetFilesByTitle();
    void CleanGDriveAcct();
    string GetFolderIdFromRoot(string folderTitleToLookFor);
    string GetChildOfFolderOnRoot(string folderOnRootToRetrieve);
    string GetFileAtTheLastDirectory(string rootFolder);
    List<string> ListAllFilesOnRoot();
  }
}