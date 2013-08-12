using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core;

namespace DocumentUploader.Core.Command {
  public class UploadCommand : ICommand {
    public UploadCommand(IMessageObserver observer, IGoulRequestHandler gRequestHandler, ICredentialStore credStore, IRefreshTokenStore refreshStore) {
      mObserver = observer;
      mHandler = gRequestHandler;
      mCredStore = credStore;
      mRefreshStore = refreshStore;
    }

    public void Execute(params string[] args) {
      mObserver.AddMessages("File uploaded");
      mHandler.UploadFile(args[1], args[2], mCredStore.Get(), mRefreshStore.Get());
    }

    private readonly ICredentialStore mCredStore;
    private readonly IGoulRequestHandler mHandler;
    private readonly IMessageObserver mObserver;
    private readonly IRefreshTokenStore mRefreshStore;
  }
}