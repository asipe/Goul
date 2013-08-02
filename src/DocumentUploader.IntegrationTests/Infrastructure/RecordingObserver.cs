using DocumentUploader.Core.Observer;

namespace DocumentUploader.IntegrationTests.Infrastructure {
  public class RecordingObserver : IMessageObserver {
    public void AddMessages(string[] messageSet) {
      mMessages = messageSet;
    }

    public string[] GetMessageCache() {
      return mMessages;
    }

    private string[] mMessages;
  }
}