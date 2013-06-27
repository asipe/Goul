namespace Goul.Console.Core.Storage {
  public interface IRefreshTokenRepository {
    string[] Load();
    bool Exists();
    void Update(string newToken);
  }
}