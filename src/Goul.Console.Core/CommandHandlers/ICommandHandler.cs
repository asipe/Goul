// Copyright (c) Andy Sipe and Morgan Sipe. All rights reserved. Licensed under the MIT License (MIT). See License.txt in the project root for license information.

namespace Goul.Console.Core.CommandHandlers {
  public interface ICommandHandler {
    void Execute(params string[] args);
  }
}