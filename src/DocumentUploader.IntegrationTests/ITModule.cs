using Autofac;
using DocumentUploader.Core;

namespace DocumentUploader.IntegrationTests {
  public class ITModule : Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<ConsoleObserver>()
        .InstancePerLifetimeScope()
        .As<IMessageObserver>();
    } 
  }
}