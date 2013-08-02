using System;
using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Output {
  public class ConsoleWriter : IMessageObserver {
    public void AddMessages(params string[] messages) {
      Array.ForEach(messages, Console.WriteLine);
    }
  }
}