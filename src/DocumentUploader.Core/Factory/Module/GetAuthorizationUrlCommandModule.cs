using Autofac;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.Factory.Module {
  public class GetAuthorizationUrl : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<GetAuthorizationUrlCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("getauthorizationurl");
    }
  }
}