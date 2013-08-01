using Autofac;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.Factory.Module {
  class SetCredentialsModule:Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<SetCredentialsCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("setcredentials");
    }
  }
}
