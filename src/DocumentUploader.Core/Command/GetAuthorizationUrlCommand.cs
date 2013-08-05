using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;

namespace DocumentUploader.Core.Command {
  public class GetAuthorizationUrlCommand : ICommand {
    public GetAuthorizationUrlCommand(IMessageObserver observer,
                                      ICredentialStore store,
                                      IGoulRequestHandler handler) {
      mObserver = observer;
      mStore = store;
      mHandler = handler;
    }

    public void Execute(params string[] messages) {
      mObserver.AddMessages(mHandler.GetAuthUrl(mStore.Get()));
    }

    private readonly IGoulRequestHandler mHandler;
    private readonly IMessageObserver mObserver;
    private readonly ICredentialStore mStore;
  }
}