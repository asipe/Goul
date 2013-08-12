using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Command {
  public class HelpCommand : ICommand {
    public HelpCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] args) {
      mObserver.AddMessages("Goul Document Uploader Version 0.1",
                            "Commands:",
                            "setcredentials xClient_IDx xClient_Secretx | Sets the client id and the client secret to a local .txt file",
                            "listcredentials | lists the credentials",
                            "clearcredentials | deletes ALL of the credential files");
    }

    private readonly IMessageObserver mObserver;
  }
}