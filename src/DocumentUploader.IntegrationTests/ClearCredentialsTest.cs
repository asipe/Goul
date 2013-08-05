﻿using DocumentUploader.Core.App;
using DocumentUploader.Core.Factory;
using DocumentUploader.Core.Factory.Module;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;
using DocumentUploader.IntegrationTests.Infrastructure.Modules;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace DocumentUploader.IntegrationTests {
  [TestFixture]
  public class ClearCredentialsTest : BaseTestCase {
    [Test]
    public void TestThatClearDeletesTheCredentialsFile() {
      mApp.Execute("setcredentials", "randomVal", "seeminglyRandomVal");
      mApp.Execute("clearcredentials");

      Assert.That(mFile.Exists("credentials.txt"), Is.False);
      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(BA("Credentials Cleared")));
    }

    [Test]
    public void TestThatTheCorrectMessageIsSentWhenTheCredentialsFileIsMissing() {
      mApp.Execute("clearcredentials");
      Assert.That(mMessageObserver.GetMessages(), Is.EqualTo(BA("Could not find the Credentials file")));
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