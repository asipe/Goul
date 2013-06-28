// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using SupaCharge.Core.IOAbstractions;

namespace Goul.Console.Core.Storage {
  public class RefreshTokenRepository : IRefreshTokenRepository {
    public RefreshTokenRepository(IFile file, string filePath) {
      mFile = file;
      mPath = filePath;
    }

    public string[] Load() {
      return mFile.ReadAllLines(mPath);
    }

    public bool Exists() {
      return mFile.Exists(mPath);
    }

    public void Update(string newToken) {
      mFile.WriteAllText("refreshToken.txt", newToken);
    }

    private readonly IFile mFile;
    private readonly string mPath;
  }
}