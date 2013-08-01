using Autofac;
using DocumentUploader.Core.Command;

namespace DocumentUploader.Core.Factory.Module {
  public class HelpCommandModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<HelpCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("help");
    }
  }
}