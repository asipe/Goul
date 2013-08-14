using Goul.Core;
using Goul.Core.Tokens;

namespace DocumentUploader.Core.Models {
  public interface IRefreshTokenStore {
    RefreshToken Get();
    void Update(RefreshToken token);
  }
}