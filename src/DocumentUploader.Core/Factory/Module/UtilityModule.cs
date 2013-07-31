using Autofac;
using DocumentUploader.Core.Observer;

namespace DocumentUploader.Core.Factory.Module {
  public class UtilityModule:Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<App.App>()
        .InstancePerLifetimeScope()
        .As<IApp>();

      builder
        .RegisterType<ConsoleWriter>()
        .SingleInstance()
        .As<IMessageObserver>();
    }
  }
}
