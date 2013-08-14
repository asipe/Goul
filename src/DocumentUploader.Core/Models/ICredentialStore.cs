using Goul.Core.Tokens;

namespace DocumentUploader.Core.Models {
  public interface ICredentialStore {
    void Update(Credentials credentials);
    Credentials Get();
  }
}