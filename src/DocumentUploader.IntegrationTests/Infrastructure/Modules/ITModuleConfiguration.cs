using Autofac;
using DocumentUploader.Core.Factory;

namespace DocumentUploader.IntegrationTests.Infrastructure.Modules {
  public class ITModuleConfiguration : IModuleConfiguration {
    public void Init(ContainerBuilder builder) {
      builder.RegisterModule(new ITModule());
    }
  }
}