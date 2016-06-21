using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.Core
{
    public interface IModuleInitializer
    {
        void Init(IServiceCollection serviceCollection);
    }
}
