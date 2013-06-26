namespace Goul.Console.Core {
  public interface IUploadHandler {
    void Execute(string fileToUpload, string fileName);
  }
}