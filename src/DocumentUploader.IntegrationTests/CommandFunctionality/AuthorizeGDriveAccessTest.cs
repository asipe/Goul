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

namespace DocumentUploader.IntegrationTests.CommandFunctionality {
  [TestFixture]
  public class AuthorizeGDriveAccessTest : BaseTestCase {
    [Test]
    [Explicit]
    public void InitTest() {
      mApp.Execute("authorize", File.ReadAllLines("Refresh_AuthToken_Test_Use_Only.txt")[0]);

      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(BA("Authorized")));
      var value = mFile.ReadAllLines("refreshToken.txt")[0];
      Assert.That(value.Length, Is.GreaterThan(5));
      Assert.That(value[0], Is.EqualTo('1'));
      File.Delete("refreshToken.txt");
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