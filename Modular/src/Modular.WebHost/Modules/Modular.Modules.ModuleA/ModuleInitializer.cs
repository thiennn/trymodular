using ExtraDepenencyTest;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core;
using Modular.Modules.ModuleA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.Modules.ModuleA
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Init(IServiceCollection services)
        {
            services.AddTransient<IAnotherTestService, AnotherTestService>();
            services.AddTransient<ITestService, TestService>();

        }
    }
}
