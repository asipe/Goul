using Goul.Core;

namespace DocumentUploader.Core.Models {
  public interface ICredentialStore {
    void Update(Credentials credentials);
    Credentials Get();
  }
}