namespace DocumentUploader.Core {
  public class HelpCommand:ICommand {
    public HelpCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(string[] commandArgs) {
      mObserver.Notify(commandArgs[0]);
    }

    private readonly IMessageObserver mObserver;
  }
}
