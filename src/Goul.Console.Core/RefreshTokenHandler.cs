using System.IO;

namespace Goul.Console.Core {
  internal class RefreshTokenHandler {
    public string GetRefreshToken() {
      System.Console.WriteLine("hello");
      return File.Exists("refreshToken.txt")
               ? File.ReadAllText("refreshToken.txt")
               : "";
    }

    public void Update(string newToken) {
      System.Console.WriteLine("newToken: " + newToken);
      File.WriteAllText("refreshToken.txt", newToken);
    }
  }
}