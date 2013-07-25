// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using System.IO;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Goul.Console.Core.Storage;
using Goul.Core;
using SupaCharge.Core.IOAbstractions;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Console.Core.CommandHandlers {
  public class UploaderHandler : ICommandHandler {
    public void Execute(params string[] args) {
      var service = GetDriveService.GetService();

      var body = new File {Title = args[1], Description = "A test document"};
      var stream = new MemoryStream(System.IO.File.ReadAllBytes(args[0]));

      var request = service.Files.Insert(body, stream, DetermineContentType(args[0]));
      request.Convert = true;

      request.Upload();
      System.Console.WriteLine("File Uploaded");
    }

    private static string DetermineContentType(string filePath) {
      var fileType = new FileInfo(filePath).Extension;
      var contentType = "text/plain";

      if (fileType == ".csv") {
        contentType = "text/csv";
      }

      return contentType;
    }

    private void ListTestFileIDs() {

    }
  }
}


//Update
//Upload branches of folders
//Update based on these branches