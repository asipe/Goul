// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using Goul.Core;

namespace Goul.Console.Core.Storage {
  public interface ICredentialsRepository {
    Credentials Load();
    void Update(Credentials credentials);
  }
}