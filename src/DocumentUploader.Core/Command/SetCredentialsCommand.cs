using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Command {
  public class SetCredentialsCommand : ICommand {
    public SetCredentialsCommand(IMessageObserver observer, ICredentialStore storage) {
      mObserver = observer;
      mStorage = storage;
    }

    public void Execute(string[] messages) {
      if (messages.Length == 3) {
        mObserver.AddMessages("Credentials Set");
        mStorage.Update(new CredentialsFile {ClientID = messages[1], ClientSecret = messages[2]});
      } else mObserver.AddMessages("Invalid amount of arguments");
    }

    public CredentialsFile CredentialsBuilder(string clientId, string clientsecret) {
      return new CredentialsFile { ClientID = clientId, ClientSecret = clientsecret };
    }

    private readonly IMessageObserver mObserver;
    private readonly ICredentialStore mStorage;
  }
}