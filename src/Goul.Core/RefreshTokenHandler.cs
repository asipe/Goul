using System;
using System.IO;

namespace Goul.Core {
  internal class RefreshTokenHandler {
    public string GetRefreshToken() {
      Console.WriteLine("hello");
      return File.Exists("refreshToken.txt")
               ? File.ReadAllText("refreshToken.txt")
               : "";
    }

    public void Update(string newToken) {
      Console.WriteLine("newToken: " + newToken);
      File.WriteAllText("refreshToken.txt", newToken);
    }
  }
}