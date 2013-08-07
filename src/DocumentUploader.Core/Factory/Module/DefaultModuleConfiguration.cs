using Autofac;

namespace DocumentUploader.Core.Factory.Module {
  public class DefaultModuleConfiguration : IModuleConfiguration {
    public void Init(ContainerBuilder builder) {
      builder.RegisterModule(new AppModule());
      builder.RegisterModule(new HelpCommandModule());
      builder.RegisterModule(new UtilityModule());
      builder.RegisterModule(new SetCredentialsModule());
      builder.RegisterModule(new CredentialStoreModule());
      builder.RegisterModule(new ListCommandModule());
      builder.RegisterModule(new ClearCommandModule());
      builder.RegisterModule(new GetAuthorizationUrl());
      builder.RegisterModule(new GoulModule());
      builder.RegisterModule(new AuthorizeCommandModule());
    }
  }
}