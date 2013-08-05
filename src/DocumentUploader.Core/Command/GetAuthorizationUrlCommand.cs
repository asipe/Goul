using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Command {
  public class GetAuthorizationUrlCommand : ICommand {
    public GetAuthorizationUrlCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] messages) {
      mObserver.AddMessages("url.com");
    }

    private readonly IMessageObserver mObserver;
  }
}