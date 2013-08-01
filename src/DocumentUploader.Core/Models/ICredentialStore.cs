namespace DocumentUploader.Core.Models {
  public interface ICredentialStore {
    CredentialsFile Get();
    void Update(CredentialsFile credentials);
  }
}