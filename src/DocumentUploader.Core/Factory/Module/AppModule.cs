﻿using Autofac;
using DocumentUploader.Core.App;

namespace DocumentUploader.Core.Factory.Module {
  public class AppModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<DocUploaderApp>()
        .InstancePerLifetimeScope()
        .As<IApp>();
    }
  }
}