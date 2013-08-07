using System;
using System.IO;
using NUnit.Framework;

namespace DocumentUploader.IntegrationTests {
  [SetUpFixture]
  public sealed class GlobalSetup {
    [SetUp]
    public void DoSetup() {
      Console.WriteLine("");
      Console.WriteLine("================================================================================");
      Console.WriteLine("================================================================================");
      Console.WriteLine("");
      Console.WriteLine("These integration tests will fry the given Google Drive Account.");
      Console.WriteLine("Make sure you're okay with that account being melted.");
      Console.WriteLine("");
      Console.WriteLine("================================================================================");
      Console.WriteLine("================================================================================");
      Console.WriteLine("");
     
      if (!File.Exists("Credentials Test Use Only.txt")) 
      Assert.Fail("Credentials file for test use could not be found");
    }
  }
}