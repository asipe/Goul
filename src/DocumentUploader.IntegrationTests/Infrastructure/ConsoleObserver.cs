using System.Collections.Generic;
using DocumentUploader.Core.Observer;

namespace DocumentUploader.IntegrationTests.Infrastructure {
  public class ConsoleObserver:IMessageObserver {
    public void AddMessage(string message) {
      mCommandMessages.Add(message);
    }
    
    public string[] GetCommandCache() {
      return mCommandMessages.ToArray();
    }

    private readonly List<string> mCommandMessages = new List<string>();
  }
}
