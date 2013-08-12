using DocumentUploader.Core.Observer;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Command {
  public class ClearCredentialsCommand : ICommand {
    public ClearCredentialsCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(string[] args) {
      var file = new DotNetFile();
      if (file.Exists("credentials.txt")) {
        file.Delete("credentials.txt");
        mObserver.AddMessages("Credentials Cleared");
      } else mObserver.AddMessages("Could not find the Credentials file");
    }

    private readonly IMessageObserver mObserver;
  }
}