using Goul.Core.Tokens;
using SupaCharge.Core.IOAbstractions;

namespace DocumentUploader.Core.Models {
  public class RefreshTokenStore : IRefreshTokenStore {
    public RefreshTokenStore(IFile file, string path) {
      mFile = file;
      mPath = path;
    }

    public RefreshToken Get() {
      return new RefreshToken {Token = mFile.ReadAllLines(mPath)[0]};
    }

    public void Update(RefreshToken token) {
      mFile.WriteAllText(mPath, token.Token);
    }

    private readonly IFile mFile;
    private readonly string mPath;
  }
}