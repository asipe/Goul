using Goul.Core;

namespace DocumentUploader.Core.Models {
  public interface IStore {
    Credentials Get();
    void Update(Credentials credentials);
  }
}