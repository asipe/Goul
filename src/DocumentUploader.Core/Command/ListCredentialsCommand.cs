using DocumentUploader.Core.Observer;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Command {
  public class ListCredentialsCommand : ICommand {
    public ListCredentialsCommand(IMessageObserver observer, IFile file) {
      mObserver = observer;
      mFile = file;
    }

    public void Execute(params string[] args) {
      if (mFile.Exists("credentials.txt"))
        mObserver.AddMessages(mFile.ReadAllLines("credentials.txt"));
      else mObserver.AddMessages("Could not find the Credentials file");
    }

    private readonly IMessageObserver mObserver;
    private readonly IFile mFile;
  }
}