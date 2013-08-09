using System;
using System.IO;
using Goul.Core;
using NUnit.Framework;

namespace DocumentUploader.IntegrationTests {
  [SetUpFixture]
  public sealed class GlobalSetup {
    [SetUp]
    public void DoSetup() {
      //Console.WriteLine("");
      //Console.WriteLine("================================================================================");
      //Console.WriteLine("================================================================================");
      //Console.WriteLine("");
      //Console.WriteLine("These integration tests will fry the given Google Drive Account.");
      //Console.WriteLine("Make sure you're okay with that account being melted.");
      //Console.WriteLine("");
      //Console.WriteLine("================================================================================");
      //Console.WriteLine("================================================================================");
      //Console.WriteLine("");

      //if (!File.Exists("Credentials_Test_Use_Only.txt") || File.ReadAllLines("Credentials_Test_Use_Only.txt").Length < 2) Assert.Fail("Credentials file for test use could not be found or it does not have the correct amount of credentials");

      //if (!File.Exists("Refresh_AuthToken_Test_Use_Only.txt") || File.ReadAllLines("Refresh_AuthToken_Test_Use_Only.txt").Length == 0) {
      //  var goul = new GoulRequestHandler();
      //  var file = File.ReadAllLines("Credentials_Test_Use_Only.txt");
      //  Assert.Fail("Could not find a refresh token. Go to this location to generate an authentication token: " + goul.GetAuthUrl(new Credentials {ClientID = file[0], ClientSecret = file[1]}));
      //}
    }
  }
}