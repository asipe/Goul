using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;

namespace DocumentUploader.Core.Command {
  public class AuthorizeCommand : ICommand {
    public AuthorizeCommand(IMessageObserver observer, IRefreshTokenStore refreshStorage, ICredentialStore credentialStore, IGoulRequestHandler handler) {
      mObserver = observer;
      mRefreshStorage = refreshStorage;
      mCredStore = credentialStore;
      mHandler = handler;
    }

    public void Execute(params string[] messages) {
      mRefreshStorage.Update(new RefreshToken {
        Token = mHandler.CreateRefreshToken(mCredStore.Get(), messages[1])
      });
      mObserver.AddMessages("Authorized");
    }

    private readonly IGoulRequestHandler mHandler;
    private readonly IMessageObserver mObserver;
    private readonly IRefreshTokenStore mRefreshStorage;
    private readonly ICredentialStore mCredStore;
  }
}