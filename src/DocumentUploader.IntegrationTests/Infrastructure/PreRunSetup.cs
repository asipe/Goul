using System;
using System.IO;
using NUnit.Framework;

namespace DocumentUploader.IntegrationTests.Infrastructure {
  [SetUpFixture]
  public sealed class GlobalSetup {
    [SetUp]
    public void DoSetup() {

      if (!CheckForTestingFiles()) {
        Console.WriteLine("");
        Console.WriteLine("===========================");
        Console.WriteLine("===========================");
        Console.WriteLine("The Integration Tests will not run.");
        Console.WriteLine("You will need to add a testconfigs folder to the development root");
        Console.WriteLine("Then add 3 files to the testconfigs folder:");
        Console.WriteLine("credentials.txt: with valid credentials");
        Console.WriteLine("refreshToken.txt: with a valid refresh token");
        Console.WriteLine("file.txt: an empty text file.");
        Console.WriteLine("===========================");
        Console.WriteLine("===========================");
        Console.WriteLine("");
        Assert.Fail();
      }
    }

    private static bool CheckForTestingFiles() {
      var provider = new TestConfigurationProvider();
      return Directory.Exists(Path.Combine(provider.GetDevelopmentRoot(), "testconfigs"));
    }
  }
}