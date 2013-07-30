using DocumentUploader.Core.Factory;
using Autofac;

namespace DocumentUploader.IntegrationTests {
  public class ITModuleConfiguration : IModuleConfiguration {
    public void Init(ContainerBuilder builder) {
      builder.RegisterModule(new ITModule());
    }
  }
}