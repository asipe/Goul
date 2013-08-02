using Autofac;

namespace DocumentUploader.Core.Factory {
  public interface IModuleConfiguration {
    void Init(ContainerBuilder builder);
  }
}