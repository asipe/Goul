namespace DocumentUploader.Core.Factory {
  public interface IFactory {
    T Build<T>();
  }
}