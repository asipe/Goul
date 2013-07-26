using Goul.Console.Core;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests {
  [TestFixture]
  public class UpdaterTest:BaseTestCase {
    [Test]
    public void UpdateASingleFileOnRoot() {
      //mIsUpdateRequired.Setup(u => u.CheckDirectoryForUpdate(new[] { "file1" }, "file1")).Returns(true);
    }

    [SetUp]
    public void DoSetup() {
      mUpdater = new Updater();
      mIsUpdateRequired = Mok<IsUpdateRequired>();
    }

    private Updater mUpdater;
    private Mock<IsUpdateRequired> mIsUpdateRequired;
  }
}