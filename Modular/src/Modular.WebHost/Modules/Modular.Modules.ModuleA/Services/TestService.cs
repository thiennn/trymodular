using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.Modules.ModuleA.Services
{
    public class TestService : ITestService
    {
        public string Test()
        {
            return "This is a test, return by Test method in Test Service";
        }
    }
}
