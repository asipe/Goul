using Autofac;

namespace DocumentUploader.Core.Factory.Module {
  public class AppModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<App>()
        .InstancePerLifetimeScope()
        .As<IApp>();
    }
  }
}