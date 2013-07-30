using Autofac;

namespace DocumentUploader.Core.Factory.Module {
  public class DefaultModuleConfiguration : IModuleConfiguration {
    public void Init(ContainerBuilder builder) {
      builder.RegisterModule(new AppModule());
      builder.RegisterModule(new HelpCommandModule());
    }
  }
}