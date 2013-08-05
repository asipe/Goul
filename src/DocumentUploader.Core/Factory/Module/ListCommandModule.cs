using Autofac;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.Factory.Module {
  internal class ListCommandModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<ListCredentialsCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("listcredentials");
    }
  }
}