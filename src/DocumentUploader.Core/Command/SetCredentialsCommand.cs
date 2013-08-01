using System;
using DocumentUploader.Core.Observer;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Command {
  public class SetCredentialsCommand:ICommand {
    public SetCredentialsCommand(IMessageObserver observer) {
      mObserver = observer;
    }

    public void Execute(string[] messages) {
      if (messages.Length == 3) {
        var output = new[] { "Credentials Set" };
        mObserver.AddMessages(output);
        new DotNetFile().WriteAllText("credentials.txt", String.Format("{0}" + Environment.NewLine + "{1}", messages[1], messages[2]));
      } else {
        mObserver.AddMessages(new[] { "Invalid amount of arguments" });
      }
    }

    private readonly IMessageObserver mObserver;
  }
}
