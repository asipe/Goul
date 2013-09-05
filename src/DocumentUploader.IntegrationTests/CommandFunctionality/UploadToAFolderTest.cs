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
  public class UploadToAFolderTest : BaseTestCase {
    [Test]
    public void TestUploadingAFileWithAnAlreadyExistantParent() {
      mFolderManager.SetupFolders(1);
      mApp.Execute("upload", "file.txt", @"TestingFolder0\file");
      Assert.That(mFileManager.NumberOfFiles(), Is.EqualTo(2));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle(), Is.EqualTo(BA("TestingFolder0")));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      var file = mFileManager.GetFileAtTheLastDirectory("TestingFolder0");
      Assert.That(mFileManager.GetFileMimeType(file), Is.EqualTo("application/vnd.google-apps.document"));
    }

    [Test]
    public void TestUploadingAFileToASetOf3Folders() {
      mFolderManager.SetupFolders(3);
      mApp.Execute("upload", "file.txt", @"TestingFolder0\TestingFolder1\TestingFolder2\file");
      Assert.That(mFileManager.NumberOfFiles(), Is.EqualTo(4));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[0], Is.EqualTo("TestingFolder0"));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      var file = mFileManager.GetFileAtTheLastDirectory("TestingFolder0");
      Assert.That(mFileManager.GetFileMimeType(file), Is.EqualTo("application/vnd.google-apps.document"));
    }

    [Test]
    public void TestUploadingAFileToAFolderWhichAlreadyHasFilesInIt() {
      mFolderManager.SetupFolders(1);
      mApp.Execute("upload", "file.txt", @"TestingFolder0");
      mApp.Execute("upload", "file.txt", @"TestingFolder0\file");
      Assert.That(mFileManager.NumberOfFiles(), Is.EqualTo(3));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[0], Is.EqualTo("TestingFolder0"));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(1));
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));
      var file = mFileManager.GetFileAtTheLastDirectory("TestingFolder0");
      Assert.That(mFileManager.GetFileMimeType(file), Is.EqualTo("application/vnd.google-apps.document"));
    }

    [Test]
    public void TestUploadingFilesToADifferentSetOfFoldersWorksCorrectly() {
      mFolderManager.SetupFolders(3);
      mApp.Execute("upload", "file.txt", @"MyFolder\file");
      mApp.Execute("upload", "file.txt", @"MyFolder\otherFile");
      mApp.Execute("upload", "file.txt", @"OtherFolder\myFile");
      Assert.That(mFileManager.NumberOfFiles(), Is.EqualTo(8));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[0], Is.EqualTo("OtherFolder"));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[1], Is.EqualTo("MyFolder"));
      Assert.That(mFileManager.ListAllFilesOnRootByTitle()[2], Is.EqualTo("TestingFolder0"));
      Assert.That(mFileManager.ListAllFoldersOnRootById().Count, Is.EqualTo(3));
      Assert.That(mObserver.GetMessages(), Is.EqualTo(BA("File uploaded")));

      var file = mFileManager.GetFileAtTheLastDirectory("MyFolder");
      var otherFile = mFileManager.GetFileAtTheLastDirectory("OtherFolder");
      Assert.That(mFileManager.GetFileMimeType(file), Is.EqualTo("application/vnd.google-apps.document"));
      Assert.That(mFileManager.GetFileMimeType(otherFile), Is.EqualTo("application/vnd.google-apps.document"));
    }

    [SetUp]
    public void Setup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
      mRefreshToken = new RefreshTokenStore(mFile, "refreshToken.txt");
      mCredentials = new CredentialStore(mFile, "credentials.txt");

      var provider = new TestConfigurationProvider();
      provider.SetupCredentialsFile();
      provider.SetupRefreshTokenFile();
      provider.SetupDummyFile();

      mFileManager = new GDriveFileManager(mCredentials.Get(), mRefreshToken.Get());
      mFileManager.CleanGDriveAcct();

      mFolderManager = new GDriveFolderManager(mCredentials.Get(), mRefreshToken.Get());
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mObserver;
    private IApp mApp;
    private ICredentialStore mCredentials;
    private IRefreshTokenStore mRefreshToken;
    private IFileManager mFileManager;
    private IFolderManager mFolderManager;
  }
}