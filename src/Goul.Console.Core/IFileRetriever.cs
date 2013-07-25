namespace Goul.Console.Core {
  public interface IFileRetriever {
    string[] RetrieveFilesFromSpecificDirectory(string folderId);
  }
}