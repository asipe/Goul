using Autofac;
using DocumentUploader.Core.Observer;

namespace DocumentUploader.IntegrationTests.Infrastructure.Modules {
  public class ITModule : Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<RecordingObserver>()
        .InstancePerLifetimeScope()
        .As<IMessageObserver>();
    }
  }
}