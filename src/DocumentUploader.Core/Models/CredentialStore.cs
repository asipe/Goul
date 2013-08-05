using System;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Models {
  public class CredentialStore : ICredentialStore {
    public CredentialStore(IFile file, string path) {
      mFile = file;
      mPath = path;
    }

    public Credentials Get() {
      var lines = mFile.ReadAllLines(mPath);
      return new Credentials {ClientID = lines[0], ClientSecret = lines[1]};
    }

    public void Update(Credentials credentials) {
      mFile.WriteAllText(mPath, string.Format("{0}{1}{2}", credentials.ClientID, Environment.NewLine, credentials.ClientSecret));
    }

    private readonly IFile mFile;
    private readonly string mPath;
  }
}