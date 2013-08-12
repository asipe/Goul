using NUnit.Framework;

namespace DocumentUploader.IntegrationTests.Infrastructure {
  [SetUpFixture]
  public sealed class GlobalSetup {
    [SetUp]
    public void DoSetup() {
      //Update this guy to check the testConfigs folder for the necessary files.
    }
  }
}