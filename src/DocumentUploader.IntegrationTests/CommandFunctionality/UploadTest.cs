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

namespace DocumentUploader.IntegrationTests.CommandFunctionality {
  [TestFixture]
  public class UploadTest : BaseTestCase {
    [Test]
    public void TestUploadWith3ArgsUploadsAFileOnly() {
      mApp.Execute("upload", "file.txt", "myFile");
      var files = mHandler.GetFilesByTitle(mCredentials.Get(), mRefreshToken.Get());

      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      Assert.That(files.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestUploadWith4ArgsUploadsAFolder() {
      mApp.Execute("upload", "file.txt", "fileTitle", "folder1");
      var folder = mHandler.GetFolderFromRoot("folder1", mCredentials.Get(), mRefreshToken.Get());
      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(BA("Folder Uploaded")));
      // Assert.That(folder.Length, Is.GreaterThan(3));
    }

    [SetUp]
    public void Setup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mMessageObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
      mRefreshToken = new RefreshTokenStore(mFile, "refreshToken.txt");
      mCredentials = new CredentialStore(mFile, "credentials.txt");
      mHandler = new GoulRequestHandler();
      var provider = new TestConfigurationProvider();
      provider.SetupCredentialsFile();
      provider.SetupRefreshTokenFile();
      provider.SetupDummyFile();
      mHandler.DeleteAllFiles(mCredentials.Get(), mRefreshToken.Get());
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