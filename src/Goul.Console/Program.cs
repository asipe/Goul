// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using Goul.Console.Core;

namespace Goul.Console {
  internal class Program {
    private static int Main(string[] args) {
      try {
        var setup = new Setup();
        new App(setup.SetupGetAuthUrl(), setup.SetupAuthorizerHandler(), setup.SetupUploadHandler()).RunCommand(args);
        return 0;
      } catch (Exception e) {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
        return 1;
      }
    }
  }
}