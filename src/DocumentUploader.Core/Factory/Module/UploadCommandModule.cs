using Autofac;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.Factory.Module {
  internal class UploadCommandModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<UploadCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("upload");
    }
  }
}