namespace DocumentUploader.Core {
  public interface IFactory {
     T Build<T>();
  }
}