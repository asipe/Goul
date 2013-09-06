using System;
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
using SupaCharge.Core.ThreadingAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests.CommandFunctionality {
  [TestFixture]
  public class UploadTest : BaseTestCase {
    [Test]
    public void TestUploadingAFileOnly() {
      var name = Guid.NewGuid().ToString("N");
      mApp.Execute("upload", "file.txt", name);
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));

      new Retry(30, 125)
        .WithWork(x => {
          Assert.That(mManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
          Assert.That(mManager.ListAllFilesOnRootByTitle(), Is.EqualTo(BA(name)));
          Assert.That(mManager.ListAllFoldersOnRootById().Count, Is.EqualTo(0));
          Assert.That(mManager.NumberOfFiles(), Is.EqualTo(1));
        })
        .Start();
    }

    [Test]
    public void TestUploadWithAFolderAndAFileUploadsBoth() {
      mApp.Execute("upload", "file.txt", @"folder3\file");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      CheckThatGivenFilesExist("folder3");
      Assert.That(mManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mManager.ListAllFilesOnRootByTitle(), Is.EqualTo(BA("folder3")));
      Assert.That(mManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));
      Assert.That(mManager.NumberOfFiles(), Is.EqualTo(2));
    }

    [Test]
    public void TestUploadWithACSVFileWorks() {
      mApp.Execute("upload", "file.csv", "file");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      Assert.That(mManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mManager.ListAllFilesOnRootByTitle(), Is.EqualTo(BA("file")));
      Assert.That(mManager.ListAllFoldersOnRootById().Count, Is.EqualTo(0));
      Assert.That(mManager.NumberOfFiles(), Is.EqualTo(1));
    }

    [Test]
    public void TestUploadWith4ArgsUploadsAFolderSetWithAFileAtTheEnd() {
      mApp.Execute("upload", "file.txt", @"folder3\folder2\folder3\file");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      CheckThatGivenFilesExist("folder3");
      Assert.That(mManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mManager.ListAllFilesOnRootByTitle(), Is.EqualTo(BA("folder3")));
      Assert.That(mManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));
      Assert.That(mManager.NumberOfFiles(), Is.EqualTo(4));
    }

    [Test]
    public void TestUploadingAFolderSetWithOnly2Folders() {
      mApp.Execute("upload", "file.txt", @"folder1\folder2\file");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      CheckThatGivenFilesExist("folder1");
      Assert.That(mManager.ListAllFilesOnRootById().Count, Is.EqualTo(1));
      Assert.That(mManager.ListAllFilesOnRootByTitle(), Is.EqualTo(BA("folder1")));
      Assert.That(mManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));
      Assert.That(mManager.NumberOfFiles(), Is.EqualTo(3));
    }

    [Test]
    public void TestUploadingTwoFolderSets() {
      mApp.Execute("upload", "file.txt", @"folder1\folder2\file");
      mApp.Execute("upload", "file.txt", @"myFolder\thisFolder\someFile");
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      CheckThatGivenFilesExist("folder1");
      CheckThatGivenFilesExist("myFolder");
      Assert.That(mManager.ListAllFilesOnRootById().Count, Is.EqualTo(2));
      Assert.That(mManager.ListAllFilesOnRootByTitle(), Is.EqualTo(BA("myFolder", "folder1")));
      Assert.That(mManager.ListAllFoldersOnRootById().Count, Is.EqualTo(2));
      Assert.That(mManager.NumberOfFiles(), Is.EqualTo(6));
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

      mManager = new GDriveFileManager(mCredentialStore.Get(), mRefreshTokenStore.Get());
      mManager.CleanGDriveAcct();
    }

    private void CheckThatGivenFilesExist(string folderToLookFor) {
      mManager.GetFolderIdFromRoot(folderToLookFor);
      mManager.GetChildOfFolderOnRoot(folderToLookFor);
      var file = mManager.GetFileAtTheLastDirectory(folderToLookFor);
      Assert.That(mManager.GetFileMimeType(file), Is.EqualTo("application/vnd.google-apps.document"));
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mObserver;
    private IApp mApp;
    private ICredentialStore mCredentialStore;
    private IRefreshTokenStore mRefreshTokenStore;
    private IFileManager mManager;
  }
}