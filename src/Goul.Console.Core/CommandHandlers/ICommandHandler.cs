namespace Goul.Console.Core.CommandHandlers {
  public interface ICommandHandler {
    void Execute(params string[] args);
  }
}