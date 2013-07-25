using Goul.Console.Core;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests {
  [TestFixture]
  public class GDriveIdRetrievalTest:BaseTestCase {
    [Test]
    public void RetrieveTheIDOfASingleFileOnRoot() {
      var ids = mTestHelper.GetIdsOfTestFiles();
      Assert.That(mIdRetriever.GetFileID("DO NOT DELETE"), Is.EqualTo(ids[0]));
    }

    //[Test]
    //public void RetrieveTheIDsOfMultipleFilesOnRoot() {
    //  var ids = mTestHelper.GetIdsOfTestFiles();
    //  Assert.That(mIdRetriever.GetMultipleFileIDs("DO NOT DELETE"), Is.EqualTo(ids[0]));
    //}

    [SetUp]
    public void DoSetup() {
      mTestHelper = new GDriveTestingHelper();
      mTestHelper.SetUpGDriveIdRetrievalTestEnv();
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