using Autofac;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.Factory.Module {
  internal class ClearCommandModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<ClearCredentialsCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("clearcredentials");
    }
  }
}