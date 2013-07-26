using Goul.Console.Core;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests {
  [TestFixture]
  public class UpdaterTest:BaseTestCase {
    [Test]
    public void TestUpdateASingleFileOnRoot() {
      var fileId = mIdRetriever.GetFileId("testFile 1 DO NOT DELETE");
      mUpdater.UpdateFile(fileId, "testFile.txt" ,"updatedFile DO NOT DELETE");
      Assert.That(mHelper.GetTitleOfFileOnRoot("updatedFile DO NOT DELETE"), Is.Not.EqualTo("testFile 1 DO NOT DELETE"));
    }

    [SetUp]
    public void DoSetup() {
      mHelper = new GDriveTestingHelper();
      mHelper.SetupTestingFilesOnRoot();
      mUpdater = new Updater();
      mIdRetriever = new GDriveIdRetrieval();
    }

    private Updater mUpdater;
    private GDriveTestingHelper mHelper;
    private GDriveIdRetrieval mIdRetriever;
  }
}