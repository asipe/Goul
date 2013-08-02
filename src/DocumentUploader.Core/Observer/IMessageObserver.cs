namespace DocumentUploader.Core.Observer {
  public interface IMessageObserver {
    void AddMessages(params string[] messageSet);
  }
}