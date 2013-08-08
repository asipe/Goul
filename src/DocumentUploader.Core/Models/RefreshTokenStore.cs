using Goul.Core;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Models {
  public class RefreshTokenStore:IRefreshTokenStore {
    public RefreshTokenStore(IFile file, string path) {
      mFile = file;
      mPath = path;
    }

    public RefreshToken Get() {
      var lines = mFile.ReadAllLines(mPath);
      return new RefreshToken {Token = lines[0]};
    }

    public void Update(RefreshToken token) {
      mFile.WriteAllText(mPath, token.Token);
    }

    private readonly IFile mFile;
    private readonly string mPath;
  }
}