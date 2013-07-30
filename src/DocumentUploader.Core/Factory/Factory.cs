using System;
using Autofac;
using IContainer = Autofac.IContainer;

namespace DocumentUploader.Core.Factory {
  public class Factory : IFactory {
    public Factory(params IModuleConfiguration[] modules) {
      var builder = new ContainerBuilder();
      Array.ForEach(modules, module => module.Init(builder));
      mContainer = builder.Build();
    }

    public T Build<T>() {
      return mContainer.Resolve<T>();
    }

    private readonly IContainer mContainer;
  }
}
