using System;

namespace Goul.Console.Core {
  public class IsUpdateRequired {
    public bool CheckDirectoryForUpdate(string[] idsToCheckAgainst, string idToCheckFor) {
      return Array.Exists(idsToCheckAgainst, f => f == idToCheckFor);
    }
  }
}
