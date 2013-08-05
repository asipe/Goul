using DocumentUploader.Core.Observer;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Command {
  public class ListCommand : ICommand {
    public ListCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] messages) {
      var file = new DotNetFile();
      if (file.Exists("credentials.txt")) {
      
      mObserver.AddMessages(file.ReadAllLines("credentials.txt"));
      } else {
        mObserver.AddMessages("Could not find the Credentials file");
      }
    }

    private readonly IMessageObserver mObserver;
  }
}