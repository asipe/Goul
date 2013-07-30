using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentUploader.Core {
  public class App {
    public App(ICommand command) {
      mCommand = command;
    }

    public void Execute(string[] commands) {
      mCommand.Execute(commands);
    }

    private ICommand mCommand;
  }
}
