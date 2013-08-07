using Autofac;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.Factory.Module {
  internal class AuthorizeCommandModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<AuthorizeCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("authorize");
    }
  }
}