using System;

namespace Goul.Console.Core {
  public class IsUpdateRequired: IUpdateRequired {
    public bool Check(string[] titleToCheckAgainst, string titleToCheckFor) {
      return Array.Exists(titleToCheckAgainst, f => f == titleToCheckFor);
    }
  }
}
