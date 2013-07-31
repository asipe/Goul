namespace DocumentUploader.Core {
  public interface ICommand {
    void Execute(string[] messages);
  }
}