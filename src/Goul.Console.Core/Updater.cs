using Google.Apis.Drive.v2;
using Goul.Console.Core.CommandHandlers;
using Goul.Core;

namespace Goul.Console.Core {
  public class Updater {
    public Updater() {
      mService = GetDriveService.GetService();
    }
    public void UpdateFile(string idOfTheFileToUpdate, string pathOfTheFileToUpdateWith, string newTitle, string oldTitle) {
      var updateReq = new IsUpdateRequired();
      var files = new GDriveFileRetriever().RetrieveFilesFromSpecificDirectory("root");

      if (updateReq.Check(files, oldTitle)) {
        var file = mService.Files.Get(idOfTheFileToUpdate).Fetch();
        file.Title = newTitle;
        var byteArray = System.IO.File.ReadAllBytes(pathOfTheFileToUpdateWith);
        var request = mService.Files.Update(file,
                                            idOfTheFileToUpdate,
                                            new System.IO.MemoryStream(byteArray),
                                            DetermineContentType.GetType(pathOfTheFileToUpdateWith));
        request.Upload();
      }      
    }

    private readonly DriveService mService;
  }
}