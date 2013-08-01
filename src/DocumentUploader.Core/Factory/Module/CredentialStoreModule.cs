using Autofac;
using DocumentUploader.Core.Models;

namespace DocumentUploader.Core.Factory.Module {
  class CredentialStoreModule:Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<CredentialStore>()
        .InstancePerLifetimeScope()
        .As<ICredentialStore>()
        .WithParameter("path", "credentials.txt");
    }
  }
}
