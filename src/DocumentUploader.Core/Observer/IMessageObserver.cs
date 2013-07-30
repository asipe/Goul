namespace DocumentUploader.Core {
  public interface IMessageObserver {
    void Notify(string message);
  }
}