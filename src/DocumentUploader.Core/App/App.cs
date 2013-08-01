using Autofac.Features.Indexed;

namespace DocumentUploader.Core.App {
  public class App:IApp {
    public App(IIndex<string, ICommand> index ) {
      mIndex = index;
    }

    public void Execute(string[] commands) {
      ICommand command;
      if (mIndex.TryGetValue(commands[0], out command))
        command.Execute(commands);
    }

    private readonly IIndex<string, ICommand> mIndex;
  }
}
