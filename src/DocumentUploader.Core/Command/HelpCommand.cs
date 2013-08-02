using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Command {
  public class HelpCommand : ICommand {
    public HelpCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] messages) {
      mObserver.AddMessages("Goul Document Uploader Version 0.1",
                            "Commands:",
                            "setcredentials xClient_IDx xClient_Secretx",
                            "...");
    }

    private readonly IMessageObserver mObserver;
  }
}