using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Command {
  public class HelpCommand : ICommand {
    public HelpCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(string[] messages) {
      mObserver.AddMessage(messages[0]);
    }

    private readonly IMessageObserver mObserver;
  }
}