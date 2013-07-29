using Goul.Console.Core;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests {
  [TestFixture]
  public class UpdaterTest:BaseTestCase {
    [Test]
    public void TestUpdateASingleFileOnRoot() {
      var lastModifiedTime = mHelper.GetLastModifiedTime("testFile 1 DO NOT DELETE");
      var fileId = mIdRetriever.GetFileId("testFile 1 DO NOT DELETE");
      mUpdater.UpdateFile(fileId, "testFile.txt", "updatedFile DO NOT DELETE", "testFile 1 DO NOT DELETE");
      Assert.That(mHelper.GetLastModifiedTime("updatedFile DO NOT DELETE"), Is.Not.EqualTo(lastModifiedTime));
    }

    [Test]
    public void TestDoNotUpdateASingleFileOnRootBecauseTheTitlesDontMatch() {
      mUpdater.UpdateFile("random file id", "testFile.txt", "updatedFile DO NOT DELETE", "random test file");
      Assert.That(mHelper.GetTitleOfFileOnRoot("testFile 1 DO NOT DELETE"), Is.EqualTo("testFile 1 DO NOT DELETE"));
    }

    [SetUp]
    public void DoSetup() {
      mHelper = new GDriveTestingHelper();
      mHelper.SetupTestingFilesOnRoot();
      mUpdater = new Updater();
      mIdRetriever = new GDriveIdRetrieval();
    }

    [TearDown]
    public void DoTearDown() {
      mHelper.DeleteTestFiles();
    }

    private Updater mUpdater;
    private GDriveTestingHelper mHelper;
    private GDriveIdRetrieval mIdRetriever;
  }
}