// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using System.IO;
using Goul.Console.Core.Storage;
using Goul.Core;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Testing;

namespace Goul.UnitTests.Console.Core.Storage {
  [TestFixture]
  public class CredentialsRepositoryTest : BaseTestCase {
    [Test]
    public void TestGettingClientDetailsWorks() {
      mFile.Setup(f => f.ReadAllLines("test.txt")).Returns(new[] {"ClientId", "clientsecret"});
      Assert.That(mCredentialsRepository.Load().ClientId, Is.EqualTo("ClientId"));
      Assert.That(mCredentialsRepository.Load().ClientSecret, Is.EqualTo("clientsecret"));
    }

    [Test]
    public void TestGettingClientDetailsOnAnEmptyFile() {
      mFile.Setup(f => f.ReadAllLines("test.txt")).Returns(new string[] {});
      Assert.Throws(typeof(IndexOutOfRangeException), () => mCredentialsRepository.Load());
    }

    [Test]
    public void TestGettingClientDetailsOnANonExistentFile() {
      mFile.Setup(f => f.ReadAllLines("test.txt")).Throws(new FileNotFoundException());
      Assert.Throws(typeof(FileNotFoundException), () => mCredentialsRepository.Load());
    }

    [Test]
    public void TestSettingClientDetailsWorks() {
      var formattedString = string.Format("{0}{1}{2}", "1", Environment.NewLine, "2");
      mFile.Setup(f => f.WriteAllText("test.txt", formattedString));

      var cred = new Credentials {ClientId = "1", ClientSecret = "2"};

      mCredentialsRepository.Set(cred);
      mFile.Verify(f => f.WriteAllText("test.txt", formattedString));
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mCredentialsRepository = new CredentialsRepository(mFile.Object, "test.txt");
    }

    private Mock<IFile> mFile;
    private ICredentialsRepository mCredentialsRepository;
  }
}