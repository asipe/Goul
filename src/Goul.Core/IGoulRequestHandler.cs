﻿namespace Goul.Core {
  public interface IGoulRequestHandler {
    string GetAuthUrl(Credentials credentials);
    string CreateRefreshToken(Credentials credentials, string authCode);
  }
}