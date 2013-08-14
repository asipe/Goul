using DocumentUploader.Core.Observer;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Command {
  public class ClearCredentialsCommand : ICommand {
    public ClearCredentialsCommand(IMessageObserver observer, IFile file) {
      mObserver = observer;
      mFile = file;
    }

    public void Execute(string[] args) {
      if (mFile.Exists("credentials.txt")) {
        mFile.Delete("credentials.txt");
        mObserver.AddMessages("Credentials Cleared");
      } else
        mObserver.AddMessages("Could not find the Credentials file");
    }

    private readonly IFile mFile;
    private readonly IMessageObserver mObserver;
  }
}