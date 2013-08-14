using Autofac;
using Goul.Core.Adapter;

namespace DocumentUploader.Core.Factory.Module {
  internal class GoulModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<GoulRequestHandler>()
        .InstancePerLifetimeScope()
        .As<IGoulRequestHandler>();
    }
  }
}