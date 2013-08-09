using System;
using System.IO;

namespace DocumentUploader.IntegrationTests {
  public class TestConfigurationProvider {
    public string GetAuthorizationToken() {
      var path = Path.Combine(GetDevelopmentRoot(), @"testconfigs\AuthToken.txt");
      return File.ReadAllLines(path)[0];
    }

    public string[] GetCredentials() {
      var path = Path.Combine(GetDevelopmentRoot(), @"testconfigs\credentials.txt");
      return File.ReadAllLines(path);
    }

    public string GetRefreshToken() {
      var path = Path.Combine(GetDevelopmentRoot(), @"testconfigs\refreshToken.txt");
      return File.ReadAllText(path);
    }

    public void SetupCredentialsFile() {
       File.WriteAllLines("credentials.txt", GetCredentials());
    }

    public void SetupRefreshTokenFile() {
      File.WriteAllText("refreshToken.txt", GetRefreshToken());
    }

    public void SetupDummyFile() {
      File.WriteAllText("file.txt", "");
    }

    public void SetupAuthTokenFile() {
      if (!File.Exists("authToken.txt")) {
        File.Create("authToken.txt");
        File.WriteAllText("authToken.txt", GetAuthorizationToken());
      } else {
        File.WriteAllLines("credentials.txt", GetCredentials());
      }
    }

    public string GetDevelopmentRoot() {
      var dir = Directory.GetCurrentDirectory();
      return Execute(dir);
    }

    private string Execute(string dir) {
      if (dir == null)
        throw new Exception("Unable to find development root");
      return IsThisRootFolder(dir) ? dir : Execute(Path.GetDirectoryName(dir));
    }

    private bool IsThisRootFolder(string path) {
      return File.Exists(Path.Combine(path, "readme.md")) &&
        Directory.Exists(Path.Combine(path, "src")) &&
        Directory.Exists(Path.Combine(path, "scripts"));
    }

   
  }
}