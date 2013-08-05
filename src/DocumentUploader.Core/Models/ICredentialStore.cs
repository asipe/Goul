using Goul.Core;

namespace DocumentUploader.Core.Models {
  public interface ICredentialStore {
    Credentials Get();
    void Update(Credentials credentials);
  }
}