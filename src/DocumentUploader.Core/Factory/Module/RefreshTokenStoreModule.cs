using Autofac;
using DocumentUploader.Core.Models;

namespace DocumentUploader.Core.Factory.Module {
  internal class RefreshTokenStoreModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<RefreshTokenStore>()
        .InstancePerLifetimeScope()
        .As<IRefreshTokenStore>()
        .WithParameter("path", "refreshToken.txt");
    }
  }
}