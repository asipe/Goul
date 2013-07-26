using System.IO;

namespace Goul.Console.Core.CommandHandlers {
  public class DetermineContentType {
    public static string GetType(string filePath) {
      var fileType = new FileInfo(filePath).Extension;
      var contentType = "text/plain";

      if (fileType == ".csv") {
        contentType = "text/csv";
      }

      return contentType;
    }
  }
}