using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;

namespace DocumentUploader.Core.Command {
  public class SetCredentialsCommand : ICommand {
    public SetCredentialsCommand(IMessageObserver observer, IStore storage) {
      mObserver = observer;
      mStorage = storage;
    }

    public void Execute(string[] messages) {
      if (messages.Length == 3) {
        mObserver.AddMessages("Credentials Set");
        mStorage.Update(new Credentials {ClientID = messages[1], ClientSecret = messages[2]});
      } else mObserver.AddMessages("Invalid amount of arguments");
    }

    public Credentials CredentialsBuilder(string clientId, string clientsecret) {
      return new Credentials {ClientID = clientId, ClientSecret = clientsecret};
    }

    private readonly IMessageObserver mObserver;
    private readonly IStore mStorage;
  }
}