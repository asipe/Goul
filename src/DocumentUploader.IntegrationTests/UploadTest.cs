using System.IO;
using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using DocumentUploader.IntegrationTests.Infrastructure.Modules;
using Goul.Core;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class UploadTest:BaseTestCase {
    [Test]
    public void TestMessage() {
      if (!File.Exists("refreshToken.txt"))
      File.Copy("Refresh_AuthToken_Test_Use_Only.txt", "refreshToken.txt");

      File.Copy("Credentials_Test_Use_Only.txt", "credentials.txt");
      mApp.Execute("upload");
      var files = mHandler.GetFilesByTitle(mCredentials.Get(), mRefreshToken.Get());

      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      Assert.That(files.Count, Is.EqualTo(0));
    }

    [SetUp]
    public void Setup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mMessageObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
      mRefreshToken = new RefreshTokenStore(mFile, "refreshToken.txt");
      mCredentials = new CredentialStore(mFile, "Credentials_Test_Use_Only.txt");
      mHandler = new GoulRequestHandler();
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mMessageObserver;
    private IApp mApp;
    private ICredentialStore mCredentials;
    private IRefreshTokenStore mRefreshToken;
    private IGoulRequestHandler mHandler;
  }
}
