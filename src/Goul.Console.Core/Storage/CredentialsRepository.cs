using System;
using Goul.Core;
using SupaCharge.Core.IOAbstractions;

namespace Goul.Console.Core.Storage {
  public class CredentialsRepository:ICredentialsRepository {
    public CredentialsRepository(IFile file, string path) {
      mFile = file;
      mPath = path;
    }

    public Credentials Load() {
      var lines = mFile.ReadAllLines(mPath);
      return new Credentials {
        ClientId = lines[0],
        ClientSecret = lines[1]
      };
    }

    public void Set(Credentials credentials) {
      mFile.WriteAllText(mPath, string.Format("{0}{1}{2}", credentials.ClientId, Environment.NewLine, credentials.ClientSecret));
    }

    private readonly IFile mFile;
    private readonly string mPath;
  }
}