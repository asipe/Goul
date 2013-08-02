using Autofac.Features.Indexed;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.App {
  public class DocUploaderApp : IApp {
    public DocUploaderApp(IIndex<string, ICommand> index) {
      mIndex = index;
    }

    public void Execute(params string[] commands) {
      ICommand command;
      if (mIndex.TryGetValue(commands[0], out command))
        command.Execute(commands);
    }

    private readonly IIndex<string, ICommand> mIndex;
  }
}