using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Command {
  public class AuthorizeCommand : ICommand {
    public AuthorizeCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] messages) {
      
      mObserver.AddMessages("Authorized");
    }

    private readonly IMessageObserver mObserver;
  }
}