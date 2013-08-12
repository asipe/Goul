using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;

namespace DocumentUploader.Core.Command {
  public class SetCredentialsCommand : ICommand {
    public SetCredentialsCommand(IMessageObserver observer, ICredentialStore storage) {
      mObserver = observer;
      mStorage = storage;
    }

    public void Execute(string[] args) {
      if (args.Length == 3) {
        mStorage.Update(new Credentials {ClientID = args[1], ClientSecret = args[2]});
        mObserver.AddMessages("Credentials Set");
      } else mObserver.AddMessages("Invalid amount of arguments");
    }

    public Credentials CredentialsBuilder(string clientId, string clientsecret) {
      return new Credentials {ClientID = clientId, ClientSecret = clientsecret};
    }

    private readonly IMessageObserver mObserver;
    private readonly ICredentialStore mStorage;
  }
}