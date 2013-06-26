using System;
using System.IO;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using File = Google.Apis.Drive.v2.Data.File;

namespace Goul.Console.Core {
  public class UploaderHandler : IUploadHandler {
    public UploaderHandler(NativeApplicationClient provider) {
      mProvider = provider;
    }

    public void Upload(string fileToUpload, string fileName) {
      var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description, "", "");

      var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
      var service = new DriveService(new BaseClientService.Initializer {
        Authenticator = auth
      });

      var body = new File();

      body.Title = fileName;
      body.Description = "A test document";

      var byteArray = System.IO.File.ReadAllBytes(fileToUpload);
      var stream = new MemoryStream(byteArray);

      var request = service.Files.Insert(body, stream, "text/plain");
      request.Convert = true;

      request.Upload();
    }

    private IAuthorizationState GetAuthorization(NativeApplicationClient appClient) {
      var tokenHandler = new RefreshTokenHandler();
      var code = tokenHandler.GetRefreshToken();
      System.Console.WriteLine(code);
      var state = new AuthorizationState(new[] {"https://www.googleapis.com/auth/drive", "https://docs.google.com/feeds"});
      state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
      state.RefreshToken = code;
      mProvider.RefreshToken(state);
      return state;
    }

    private readonly NativeApplicationClient mProvider;
  }
}