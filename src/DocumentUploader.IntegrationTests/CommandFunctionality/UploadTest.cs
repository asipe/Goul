using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using DocumentUploader.IntegrationTests.Infrastructure.Modules;
using Goul.Core.FileManagement;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests.CommandFunctionality {
  [TestFixture]
  public class UploadTest : BaseTestCase {
    [Test]
    public void TestUploadWith3ArgsUploadsAFileOnly() {
      mApp.Execute("upload", "file.txt", "myFile");
      var files = mFileManager.GetFilesByTitle();

      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      Assert.That(files.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestUploadWith1ArgsUploadsAFolder() {
      mApp.Execute("upload", "file.txt", "file", "folder3");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      mFileManager.GetFolderIdFromRoot("folder3");
    }

    [Test]
    public void TestUploadWith4ArgsUploadsAFolderSetWithAFileAtTheEnd() {
      mApp.Execute("upload", "file.txt", "file", @"folder3\folder2\folder3");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      CheckThatGivenFilesExist("folder3");
    }

    [Test]
    public void TestUploadingAFolderSetWithOnly2Folders() {
      mApp.Execute("upload", "file.txt", "file", @"folder3\folder2");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      CheckThatGivenFilesExist("folder3");
    }

    [Test]
    public void TestUploadingAFolderSetWithOnly1Folder() {
      mApp.Execute("upload", "file.txt", "file", @"folder3");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      CheckThatGivenFilesExist("folder3");
    }

    [SetUp]
    public void Setup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
      mRefreshTokenStore = new RefreshTokenStore(mFile, "refreshToken.txt");
      mCredentialStore = new CredentialStore(mFile, "credentials.txt");

      var provider = new TestConfigurationProvider();
      provider.SetupCredentialsFile();
      provider.SetupRefreshTokenFile();
      provider.SetupDummyFile();

      mFileManager = new GDriveFileManager(mCredentialStore.Get(), mRefreshTokenStore.Get());
      mFileManager.CleanGDriveAcct();
    }

    private void CheckThatGivenFilesExist(string folderToLookFor) {
      mFileManager.GetFolderIdFromRoot(folderToLookFor);
      mFileManager.GetChildOfFolderOnRoot(folderToLookFor);
      mFileManager.GetFileAtTheLastDirectory(folderToLookFor);
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mObserver;
    private IApp mApp;
    private ICredentialStore mCredentialStore;
    private IRefreshTokenStore mRefreshTokenStore;
    private IFileManager mFileManager;
  }
}