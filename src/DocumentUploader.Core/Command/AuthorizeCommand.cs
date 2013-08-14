using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core.Adapter;
using Goul.Core.Tokens;

namespace DocumentUploader.Core.Command {
  public class AuthorizeCommand : ICommand {
    public AuthorizeCommand(IMessageObserver observer, IRefreshTokenStore refreshStorage, ICredentialStore credentialStore, IGoulRequestHandler handler) {
      mObserver = observer;
      mRefreshStorage = refreshStorage;
      mCredStore = credentialStore;
      mHandler = handler;
    }

    public void Execute(params string[] args) {
      mRefreshStorage.Update(new RefreshToken {
                                                Token = mHandler.CreateRefreshToken(mCredStore.Get(), args[1])
                                              });
      mObserver.AddMessages("Authorized");
    }

    private readonly ICredentialStore mCredStore;
    private readonly IGoulRequestHandler mHandler;
    private readonly IMessageObserver mObserver;
    private readonly IRefreshTokenStore mRefreshStorage;
  }
}