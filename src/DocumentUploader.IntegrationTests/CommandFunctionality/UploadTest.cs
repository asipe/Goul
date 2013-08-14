using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using DocumentUploader.IntegrationTests.Infrastructure.Modules;
using Goul.Core.Adapter;
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

      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      Assert.That(files.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestUploadWith1ArgsUploadsAFolder() {
      mApp.Execute("upload", "file.txt", "file", "folder3");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Folder uploaded")));
      mHandler.GetFolderFromRoot("folder3", mCredentials.Get(), mRefreshToken.Get());
    }

    [Test]
    public void TestUploadWith4ArgsUploadsAFolderSetWithAFileAtTheEnd() {
      mApp.Execute("upload", "file.txt", "file", @"folder3\folder2\folder3");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Folder uploaded")));
      mHandler.GetFolderFromRoot("folder3", mCredentials.Get(), mRefreshToken.Get());
      mHandler.GetChildOfFolderOnRoot("folder3", mCredentials.Get(), mRefreshToken.Get());
      mHandler.GetFileAtTheLastDirectory("folder3", mCredentials.Get(), mRefreshToken.Get());
    }

    [Test]
    public void TestUploadingAFolderSetWithOnly2Folders() {
      mApp.Execute("upload", "file.txt", "file", @"folder3\folder2");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Folder uploaded")));
      mHandler.GetFolderFromRoot("folder3", mCredentials.Get(), mRefreshToken.Get());
      mHandler.GetChildOfFolderOnRoot("folder3", mCredentials.Get(), mRefreshToken.Get());
      mHandler.GetFileAtTheLastDirectory("folder3", mCredentials.Get(), mRefreshToken.Get());
    }

    [Test]
    public void TestUploadingAFolderSetWithOnly1Folder() {
      mApp.Execute("upload", "file.txt", "file", @"folder3");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Folder uploaded")));
      mHandler.GetFolderFromRoot("folder3", mCredentials.Get(), mRefreshToken.Get());
      mHandler.GetChildOfFolderOnRoot("folder3", mCredentials.Get(), mRefreshToken.Get());
      mHandler.GetFileAtTheLastDirectory("folder3", mCredentials.Get(), mRefreshToken.Get());
    }

    [SetUp]
    public void Setup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
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
    private RecordingObserver mObserver;
    private IApp mApp;
    private ICredentialStore mCredentials;
    private IRefreshTokenStore mRefreshToken;
    private IGoulRequestHandler mHandler;
  }
}