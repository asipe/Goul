using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;

namespace DocumentUploader.Core.Command {
  public class GetAuthorizationUrlCommand : ICommand {
    public GetAuthorizationUrlCommand(IMessageObserver observer,
                                      ICredentialStore credentialStore,
                                      IGoulRequestHandler handler) {
      mObserver = observer;
      mCredentialStore = credentialStore;
      mHandler = handler;
    }

    public void Execute(params string[] messages) {
      mObserver.AddMessages(mHandler.GetAuthUrl(mCredentialStore.Get()));
    }

    private readonly IGoulRequestHandler mHandler;
    private readonly IMessageObserver mObserver;
    private readonly ICredentialStore mCredentialStore;
  }
}