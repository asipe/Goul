using System.Collections.Generic;
using Google.Apis.Drive.v2.Data;

namespace Goul.Core.ITHelper {
  public interface IFileManager {
    List<string> GetFilesByTitle();
    void CleanGDriveAcct();
    string GetFolderIdFromRoot(string folderTitleToLookFor);
    string GetChildOfFolderOnRoot(string folderOnRootToRetrieve);
    string GetFileAtTheLastDirectory(string rootFolder);
    IList<File> ListAllFilesOnRoot();
  }
}