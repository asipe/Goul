using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace DocumentUploader.Core {
  public interface IModuleConfiguration {
    void Init(ContainerBuilder builder);
  }
}
