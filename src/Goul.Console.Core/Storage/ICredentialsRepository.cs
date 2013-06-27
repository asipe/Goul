using Goul.Core;

namespace Goul.Console.Core.Storage {
  public interface ICredentialsRepository {
    Credentials Load();
    void Set(Credentials credentials);
  }
}