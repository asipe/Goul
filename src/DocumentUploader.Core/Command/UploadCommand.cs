using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core.Adapter;

namespace DocumentUploader.Core.Command {
  public class UploadCommand : ICommand {
    public UploadCommand(IMessageObserver observer, IGoulRequestHandler gRequestHandler, ICredentialStore credStore, IRefreshTokenStore refreshStore) {
      mObserver = observer;
      mHandler = gRequestHandler;
      mCredStore = credStore;
      mRefreshStore = refreshStore;
    }

    public void Execute(params string[] args) {
      switch (args.Length) {
        case 3:
          mHandler.UploadFile(args[1], args[2], mCredStore.Get(), mRefreshStore.Get());
          mObserver.AddMessages("File uploaded");
          break;
        case 4:
          var folders = args[3].Split(new[] {'\\'});
          mHandler.UploadFileWithFolder(args[1], args[2], folders, mCredStore.Get(), mRefreshStore.Get());
          mObserver.AddMessages("Files uploaded");
          break;
      }
    }

    private readonly ICredentialStore mCredStore;
    private readonly IGoulRequestHandler mHandler;
    private readonly IMessageObserver mObserver;
    private readonly IRefreshTokenStore mRefreshStore;
  }
}