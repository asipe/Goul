// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System.IO;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Console.Core.CommandHandlers {
  public class UploaderHandler : ICommandHandler {
    public void Execute(params string[] args) {
      var service = GetDriveService.GetService();

      var body = new File {Title = args[1], Description = "A test document"};
      var stream = new MemoryStream(System.IO.File.ReadAllBytes(args[0]));

      var request = service.Files.Insert(body, stream, DetermineContentType.GetType(args[0]));
      request.Convert = true;

      request.Upload();
      System.Console.WriteLine("File Uploaded");
    }
  }
}

//Update
//Upload branches of folders
//Update based on these branches