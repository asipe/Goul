// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using Goul.Console.Core;
using Moq;
using NUnit.Framework;
using SupaCharge.Testing;

namespace Goul.UnitTests.Console.Core {
  [TestFixture]
  public class IsUpdateRequiredTest : BaseTestCase {
    [Test]
    public void TestUpdateOnASingleFileOnRootRegistersAsFalse() {
      mRetrieval.Setup(r => r.RetrieveFilesFromSpecificDirectory("root")).Returns(new[] {"file1"});
      Assert.That(mIsUpdateRequired.CheckDirectoryForUpdate(mRetrieval.Object.RetrieveFilesFromSpecificDirectory("root"), "file3"), Is.False);
    }

    [Test]
    public void TestUpdateOnASingleFileOnRootRegistersAsTrue() {
      mRetrieval.Setup(r => r.RetrieveFilesFromSpecificDirectory("root")).Returns(new[] {"file1"});
      Assert.That(mIsUpdateRequired.CheckDirectoryForUpdate(mRetrieval.Object.RetrieveFilesFromSpecificDirectory("root"), "file1"), Is.True);
    }

    [Test]
    public void TestUpdateOnMultipleFilesOnRootRegistersAsFalse() {
      mRetrieval.Setup(r => r.RetrieveFilesFromSpecificDirectory("root")).Returns(new[] {"file1", "file2", "file3"});
      Assert.That(mIsUpdateRequired.CheckDirectoryForUpdate(mRetrieval.Object.RetrieveFilesFromSpecificDirectory("root"), "joe"), Is.False);
    }

    [Test]
    public void TestUpdateOnMultipleFilesOnRootRegistersAsTrue() {
      mRetrieval.Setup(r => r.RetrieveFilesFromSpecificDirectory("root")).Returns(new[] {"file1", "file2", "file3"});
      Assert.That(mIsUpdateRequired.CheckDirectoryForUpdate(mRetrieval.Object.RetrieveFilesFromSpecificDirectory("root"), "file2"), Is.True);
    }

    [Test]
    public void TestUpdateOnNoFilesOnRootRegistersAsFalse() {
      mRetrieval.Setup(r => r.RetrieveFilesFromSpecificDirectory("randomDir")).Returns(new string[] {});
      Assert.That(mIsUpdateRequired.CheckDirectoryForUpdate(mRetrieval.Object.RetrieveFilesFromSpecificDirectory("randomDir"), "file2"), Is.False);
    }

    [SetUp]
    public void DoSetup() {
      mRetrieval = Mok<IFileRetriever>();
      mIsUpdateRequired = new IsUpdateRequired();
    }

    private Mock<IFileRetriever> mRetrieval;
    private IsUpdateRequired mIsUpdateRequired;
  }
}