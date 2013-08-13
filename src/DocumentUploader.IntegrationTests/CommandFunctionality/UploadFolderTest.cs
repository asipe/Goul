using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using DocumentUploader.IntegrationTests.Infrastructure.Modules;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests.CommandFunctionality {
  [TestFixture]
  public class UploadFolderTest : BaseTestCase {
    [Test]
    public void TestThatFolderIsSuccessFullyUploaded() {
      
    }
    
    [SetUp]
    public void DoSetup() {
      mFactory = new Factory(new DefaultModuleConfiguration(), new ITModuleConfiguration());
      mMessageObserver = (RecordingObserver)mFactory.Build<IMessageObserver>();
      mApp = mFactory.Build<IApp>();
      mFile = new DotNetFile();
    }

    private DotNetFile mFile;
    private Factory mFactory;
    private RecordingObserver mMessageObserver;
    private IApp mApp;
  }
}