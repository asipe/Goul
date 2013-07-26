using Google.Apis.Drive.v2;
using Goul.Console.Core.CommandHandlers;

namespace Goul.Console.Core {
  public class Updater {
    public Updater() {
      mService = GetDriveService.GetService();
    }
    public void UpdateFile(string idOfTheFileToUpdate, string pathOfTheFileToUpdateWith, string newTitle) {
      var file = mService.Files.Get(idOfTheFileToUpdate).Fetch();
      file.Title = newTitle;
      var byteArray = System.IO.File.ReadAllBytes(pathOfTheFileToUpdateWith);
      var request = mService.Files.Update(file,
                                          idOfTheFileToUpdate,
                                          new System.IO.MemoryStream(byteArray),
                                          DetermineContentType.GetType(pathOfTheFileToUpdateWith));
      request.Upload();
    }

    private readonly DriveService mService;
  }
}