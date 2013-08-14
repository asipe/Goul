using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;
using Goul.Core.Adapter;

namespace DocumentUploader.Core.Command {
  public class GetAuthorizationUrlCommand : ICommand {
    public GetAuthorizationUrlCommand(IMessageObserver observer,
                                      ICredentialStore credentialStore,
                                      IGoulRequestHandler handler) {
      mObserver = observer;
      mCredentialStore = credentialStore;
      mHandler = handler;
    }

    public void Execute(params string[] args) {
      mObserver.AddMessages(mHandler.GetAuthUrl(mCredentialStore.Get()));
    }

    private readonly ICredentialStore mCredentialStore;
    private readonly IGoulRequestHandler mHandler;
    private readonly IMessageObserver mObserver;
  }
}