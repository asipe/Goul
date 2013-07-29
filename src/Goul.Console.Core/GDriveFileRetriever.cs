using System.Linq;
using Goul.Console.Core.CommandHandlers;
using Goul.Core;

namespace Goul.Console.Core {
  public class GDriveFileRetriever : IFileRetriever {
    public string[] RetrieveFilesFromSpecificDirectory(string folderId) {
      var service = GetDriveService.GetService();

      var request = service.Files.List();
     // request.Q = string.Format("'{0}' in parents", folderId);

      var result = request.Fetch().Items;
      return result.Select(t => t.Title).ToArray();
    }
  }
}
