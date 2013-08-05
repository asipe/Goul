using Autofac;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.Factory.Module {
  internal class ListModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<ListCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("listcredentials");
    }
  }
}