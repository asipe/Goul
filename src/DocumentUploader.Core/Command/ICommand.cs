namespace DocumentUploader.Core.Command {
  public interface ICommand {
    void Execute(string[] messages);
  }
}