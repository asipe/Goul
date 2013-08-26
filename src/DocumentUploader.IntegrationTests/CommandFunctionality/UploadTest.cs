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
    public void TestUploadWithOnlyAFileUploadsAFileOnly() {
      mApp.Execute("upload", "file.txt", "myFile");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      Assert.That(mFileManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[0], Is.EqualTo("myFile"));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(0));
    }

    [Test]
    public void TestUploadWithAFolderAndAFileUploadsBoth() {
      mApp.Execute("upload", "file.txt", @"folder3\file");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      CheckThatGivenFilesExist("folder3");
      Assert.That(mFileManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[0], Is.EqualTo("folder3"));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));

    }

    [Test]
    public void TestUploadWithACSVFileWorks() {
      mApp.Execute("upload", "file.csv", "file");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      Assert.That(mFileManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[0], Is.EqualTo("file"));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(0));
    }

    [Test]
    public void TestUploadWith4ArgsUploadsAFolderSetWithAFileAtTheEnd() {
      mApp.Execute("upload", "file.txt", @"folder3\folder2\folder3\file");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      CheckThatGivenFilesExist("folder3");
      Assert.That(mFileManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[0], Is.EqualTo("folder3"));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));
    }

    [Test]
    public void TestUploadingAFolderSetWithOnly2Folders() {
      mApp.Execute("upload", "file.txt", @"folder1\folder2\file");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("Files uploaded")));
      CheckThatGivenFilesExist("folder1");
      mFileManager.GetFileAtTheLastDirectory("folder1");
      Assert.That(mFileManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[0], Is.EqualTo("folder1"));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));
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
      provider.CreateFileBatch();

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