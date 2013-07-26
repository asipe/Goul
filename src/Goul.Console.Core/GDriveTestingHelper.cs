using System;
using System.Linq;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Goul.Console.Core.CommandHandlers;

namespace Goul.Console.Core {
  public class GDriveTestingHelper {
    public GDriveTestingHelper() {
      mService = GetDriveService.GetService(); 
    }

    public void SetupTestingFilesOnRoot() {
      var files = CreateTestFiles();
      for (var x = 0; x < files.Length; x++) {
        var request = mService.Files.Insert(files[x]);
        request.Convert = true;
        request.Fetch();
      }
    }

    public File[] CreateTestFiles() {
      var file1 = new File { Title = "testFile 1 DO NOT DELETE"};
      var file2 = new File { Title = "testFile 2 DO NOT DELETE"};
      var file3 = new File { Title = "testFile 3 DO NOT DELETE"};
      return new [] { file1, file2, file3 };
    }

    public string[] GetIdsOfTestFiles() {
      var request = mService.Files.List();
      request.Q = "title contains 'DO NOT DELETE'";
      return request.Fetch().Items.Select(s => s.Id).ToArray();
    }

    public string GetTitleOfFileOnRoot(string title) {
      var request = mService.Files.List();
      request.Q = String.Format("title = '{0}'", title);
      System.Console.WriteLine("request.Fetch().Items.Count: {0}", request.Fetch().Items.Count);
      
      return request.Fetch().Items.Select(s => s.Title).ToArray()[0];
    }

    public void DeleteTestFiles() {
      var ids = GetIdsOfTestFiles();
      Array.ForEach(ids, id => mService.Files.Delete(id).Fetch());
    }

    public string GetLastModifiedTime(string fileTitleToGet) {
      var request = mService.Files.List();
      request.Q = String.Format("title = '{0}'", fileTitleToGet);
      var result = request.Fetch().Items;
      System.Console.WriteLine("result.Count: {0}", result.Count);
      
      return result[0].ModifiedDate;
    }


    private readonly DriveService mService;

   
  }
}
