using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Goul.Console.Core.Storage;
using Goul.Core;
using SupaCharge.Core.IOAbstractions;

namespace Goul.Console.Core.CommandHandlers {
  public static class GetDriveService {
    public static DriveService GetService() {
      var provider = Constants.GetAppClient(new Setup().GetCredentialsRepository().Load());
      var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
      var service = new DriveService(new BaseClientService.Initializer {
        Authenticator = auth
      });

      return service;
    }

    private static IAuthorizationState GetAuthorization(NativeApplicationClient appClient) {
      var tokenRepository = new RefreshTokenRepository(new DotNetFile(), "refreshToken.txt");
      var code = tokenRepository.Load()[0];

      var state = new AuthorizationState(
        Constants.GetScopes()) { Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl), RefreshToken = code };
      appClient.RefreshToken(state);
      return state;
    }
  }
}
