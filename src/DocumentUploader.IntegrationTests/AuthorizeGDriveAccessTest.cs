using System.IO;
using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using DocumentUploader.IntegrationTests.Infrastructure.Modules;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class AuthorizeGDriveAccessTest:BaseTestCase {
    [Test]
    public void InitTest() {
      File.WriteAllLines("Credentials_Test_Use_Only.txt", new [] {"123", "345"});
      mApp.Execute("authorize", "authcode");

    //  Assert.That(File.ReadAllLines("refreshToken.txt"), Is.EqualTo("123"));
   //   Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(BA("Authorize")));
    }

    [SetUp]
    public void DoSetup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mMessageObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mMessageObserver;
    private IApp mApp;
  }
}