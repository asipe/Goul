using Goul.Console.Core;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests {
  [TestFixture]
  public class GDriveIdRetrievalTest:BaseTestCase {
    [Test]
    public void RetrieveTheIDOfASingleFileOnRoot() {
      var ids = mTestHelper.GetIdsOfTestFiles();
      Assert.That(mIdRetriever.GetFileId("testFile 1 DO NOT DELETE"), Is.EqualTo(ids[0]));
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