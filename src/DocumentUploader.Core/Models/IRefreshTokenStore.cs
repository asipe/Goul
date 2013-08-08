using Goul.Core;

namespace DocumentUploader.Core.Models {
  public interface IRefreshTokenStore {
    RefreshToken Get();
    void Update(RefreshToken token);
  }
}