namespace DocumentUploader.Core.Observer {
  public interface IMessageObserver {
    void AddMessages(string[] messageSet);
  }
}