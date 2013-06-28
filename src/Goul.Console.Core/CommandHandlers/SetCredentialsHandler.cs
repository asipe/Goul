using Goul.Console.Core.Storage;
using Goul.Core;

namespace Goul.Console.Core.CommandHandlers {
  public class SetCredentialsHandler : ICommandHandler {
    public SetCredentialsHandler(CredentialsRepository credentialsRepository) {
      mCredentialsRepository = credentialsRepository;
    }

    public void Execute(params string[] args) {
      var credentials = new Credentials {ClientId = (args[0]), ClientSecret = (args[1])};
      mCredentialsRepository.Update(credentials);
    }

    private readonly CredentialsRepository mCredentialsRepository;
  }
}