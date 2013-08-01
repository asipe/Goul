using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Command {
  public class SetCredentialsCommand:ICommand {
    public SetCredentialsCommand(IMessageObserver observer, ICredentialStore storage) {
      mObserver = observer;
      mStorage = storage;
    }

    public void Execute(string[] messages) {
      if (messages.Length == 3) {
        mObserver.AddMessages(new[] { "Credentials Set" });
        mStorage.Update(new CredentialsFile{Client_ID = messages[1], Client_Secret = messages[2]});
      } else {
        mObserver.AddMessages(new[] { "Invalid amount of arguments" });
      }
    }

    private readonly IMessageObserver mObserver;
    private readonly ICredentialStore mStorage;
  }
}
