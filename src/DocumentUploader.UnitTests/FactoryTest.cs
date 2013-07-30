using Autofac;
using DocumentUploader.Core.Factory;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class FactoryTest : BaseTestCase {
    [Test]
    public void TestBuild() {
      var module = Mok<IModuleConfiguration>();
      module
        .Setup(m => m.Init(It.IsAny<ContainerBuilder>()))
        .Callback<ContainerBuilder>(b => b.Register(cc => 33));
      var factory = new Factory(module.Object);
      Assert.That(factory.Build<int>(), Is.EqualTo(33));
    }
  }
}