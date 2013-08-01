using System;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Models {
  public class CredentialStore : ICredentialStore {
    public CredentialStore(IFile file, string path) {
      mFile = file;
      mPath = path;
    }

    public CredentialsFile Get() {
      var lines = mFile.ReadAllLines(mPath);
      return new CredentialsFile {Client_ID = lines[0], Client_Secret = lines[1]};
    }

    public void Update(CredentialsFile credentials) {
      mFile.WriteAllText(mPath, string.Format("{0}{1}{2}", credentials.Client_ID, Environment.NewLine, credentials.Client_Secret));
    }

    private readonly IFile mFile;
    private readonly string mPath;
  }
}