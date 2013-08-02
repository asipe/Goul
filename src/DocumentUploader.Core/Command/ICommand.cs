namespace DocumentUploader.Core.Command {
  public interface ICommand {
    void Execute(params string[] messages);
  }
}