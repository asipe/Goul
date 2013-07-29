namespace Goul.Console.Core {
  public interface IUpdateRequired {
    bool Check(string[] idsToCheckAgainst, string idToCheckFor);
  }
}