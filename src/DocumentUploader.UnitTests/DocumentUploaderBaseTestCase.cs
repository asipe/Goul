﻿using System.Collections;
using System.Linq;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using SupaCharge.Testing;

namespace DocumentUploader.UnitTests {
  [TestFixture]
  public class DocumentUploaderBaseTestCase : BaseTestCase {
    static DocumentUploaderBaseTestCase() {
      _ObjectComparer.MaxDifferences = 10;
    }

    protected void AssertEqual(object actual, object expected) {
      Assert.That(AreEqual(actual, expected), Is.True, _ObjectComparer.DifferencesString);
    }

    protected static bool AreEqual(object actual, object expected) {
      if (actual is IEnumerable && expected is IEnumerable) {
        actual = ((IEnumerable)actual).Cast<object>().ToArray();
        expected = ((IEnumerable)expected).Cast<object>().ToArray();
      }
      return _ObjectComparer.Compare(actual, expected);
    }

    private static readonly CompareObjects _ObjectComparer = new CompareObjects();
  }
}