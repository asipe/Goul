namespace Goul.Console.Core {
  public interface IUpdateRequired {
    bool CheckDirectoryForUpdate(string[] idsToCheckAgainst, string idToCheckFor);
  }
}