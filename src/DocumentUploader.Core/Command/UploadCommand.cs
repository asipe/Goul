using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using System.Linq;
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
      var folders = args[2].Split(new[] {'\\'});
      var fileTitle = folders.Last();

      if (folders.Length == 1) {
        folders = new string[] {};
      }

      mHandler.UploadFileWithFolder(args[1], fileTitle, folders, mCredStore.Get(), mRefreshStore.Get());
      mObserver.AddMessages("Files uploaded");
    }

    private readonly ICredentialStore mCredStore;
    private readonly IGoulRequestHandler mHandler;
    private readonly IMessageObserver mObserver;
    private readonly IRefreshTokenStore mRefreshStore;
  }
}