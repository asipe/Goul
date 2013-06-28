// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using System.IO;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Goul.Console.Core.Storage;
using SupaCharge.Core.IOAbstractions;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Console.Core.CommandHandlers {
  public class UploaderHandler : ICommandHandler {
    public UploaderHandler(NativeApplicationClient provider) {
      mProvider = provider;
    }

    public void Execute(params string[] args) {
      var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description, "", "");

      var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
      var service = new DriveService(new BaseClientService.Initializer {
        Authenticator = auth
      });

      var body = new File {Title = args[1], Description = "A test document"};

      var byteArray = System.IO.File.ReadAllBytes(args[0]);
      var stream = new MemoryStream(byteArray);

      var request = service.Files.Insert(body, stream, "text/plain");
      request.Convert = true;

      request.Upload();
    }

    private IAuthorizationState GetAuthorization(NativeApplicationClient appClient) {
      var tokenRepository = new RefreshTokenRepository(new DotNetFile(), "refreshToken.txt");
      var code = tokenRepository.Load()[0];

      var state = new AuthorizationState(
        new[] {"https://www.googleapis.com/auth/drive",
               "https://docs.google.com/feeds"})
               {Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl), RefreshToken = code};
      mProvider.RefreshToken(state);
      return state;
    }

    private readonly NativeApplicationClient mProvider;
  }
}