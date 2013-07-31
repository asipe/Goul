using Autofac;
using DocumentUploader.Core;
using DocumentUploader.Core.Observer;
using DocumentUploader.IntegrationTests.Infrastructure;

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