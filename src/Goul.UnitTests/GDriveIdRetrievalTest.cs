using Goul.Console.Core;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests {
  [TestFixture]
  public class GDriveIdRetrievalTest:BaseTestCase {
    [Test]
    public void RetrieveTheIDOfASingleFileOnRoot() {
      var ids = mTestHelper.GetIdOfSpecificTestFile("testFile 1 DO NOT DELETE");
      Assert.That(mIdRetriever.GetFileId("testFile 1 DO NOT DELETE"), Is.EqualTo(ids));
    }

    [SetUp]
    public void DoSetup() {
      mTestHelper = new GDriveTestingHelper();
      mTestHelper.SetupTestingFilesOnRoot();
      mIdRetriever = new GDriveIdRetrieval();
    }

    [TearDown]
    public void DoTearDown() {
      mTestHelper.DeleteTestFiles();
    }

    private GDriveIdRetrieval mIdRetriever;
    private GDriveTestingHelper mTestHelper;
  }
}