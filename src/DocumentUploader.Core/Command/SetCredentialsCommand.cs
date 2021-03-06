﻿using DocumentUploader.Core.Models;
using DocumentUploader.Core.Observer;
using Goul.Core.Tokens;

namespace DocumentUploader.Core.Command {
  public class SetCredentialsCommand : ICommand {
    public SetCredentialsCommand(IMessageObserver observer, ICredentialStore storage) {
      mObserver = observer;
      mStorage = storage;
    }

    public void Execute(string[] args) {
      if (args.Length == 3) {
        mStorage.Update(BuildCredentials(args[1], args[2]));
        mObserver.AddMessages("Credentials Set");
      } else
        mObserver.AddMessages("Invalid amount of arguments");
    }

    private static Credentials BuildCredentials(string clientId, string clientsecret) {
      return new Credentials {ClientID = clientId, ClientSecret = clientsecret};
    }

    private readonly IMessageObserver mObserver;
    private readonly ICredentialStore mStorage;
  }
}