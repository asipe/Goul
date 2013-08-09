using System;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Drive.v2;
using Google.Apis.Services;

namespace Goul.Core {
  public class GetDriveService {
    public DriveService GetService(Credentials credentials, RefreshToken refreshToken) {
      var provider = GetAppClient(credentials);
      var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
      var service = new DriveService(new BaseClientService.Initializer {
        Authenticator = auth
      });

      mRefreshToken = refreshToken;

      return service;
    }

    private IAuthorizationState GetAuthorization(NativeApplicationClient appClient) {
      var state = new AuthorizationState(new [] {"https://www.googleapis.com/auth/drive"}) {Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl), RefreshToken = mRefreshToken.Token};
      appClient.RefreshToken(state);
      return state;
    }

    public NativeApplicationClient GetAppClient(Credentials credentials) {
      return new NativeApplicationClient(GoogleAuthenticationServer.Description, credentials.ClientID, credentials.ClientSecret);
    }

    private RefreshToken mRefreshToken;
  }
}