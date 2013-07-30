using System.Collections.Generic;

namespace DocumentUploader.Core {
  public class ConsoleObserver:IMessageObserver {
    public ConsoleObserver() {
      mMessages = new List<string>();
    }

    public string[] GetMessageCache() {
      return mMessages.ToArray();
    }

   public void Notify(string message) {
     mMessages.Add(message);
    }

    private readonly List<string> mMessages;
  }
}
