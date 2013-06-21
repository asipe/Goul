using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Goul.Console.Core {
  public class ConsoleCommandParser {
    public void Parse(string[] args) {
      Command = args[0];
      
      if (args.Length == 2) {
        CommandArg = args[1];
      }

      BeginOperation();
    }

    private void BeginOperation() {
      if (Command != "authUrl") {
        throw (new ArgumentException());
      }


    }

    public string Command { get; set; }
    public string CommandArg { get; set; }
  }
}
