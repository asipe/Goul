using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Command {
  public class UploadCommand : ICommand {
    public UploadCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] args) {
      mObserver.AddMessages("File uploaded");
    }

    private readonly IMessageObserver mObserver;
  }
}