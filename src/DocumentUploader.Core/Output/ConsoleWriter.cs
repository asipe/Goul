using System;
using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Output {
  public class ConsoleWriter : IMessageObserver {
    public void AddMessages(string[] messages) {
      Console.WriteLine();
      for (var x = 0; x < messages.Length; x++) Console.WriteLine(messages[x]);
    }
  }
}