using Autofac;
using DocumentUploader.Core.Models;

namespace DocumentUploader.Core.Factory.Module {
  internal class CredentialStoreModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<CredentialStore>()
        .InstancePerLifetimeScope()
        .As<IStore>()
        .WithParameter("path", "credentials.txt");
    }
  }
}