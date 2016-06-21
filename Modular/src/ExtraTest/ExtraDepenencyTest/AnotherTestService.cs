using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraDepenencyTest
{
    public class AnotherTestService : IAnotherTestService
    {
        public string Test()
        {
            return "Other service outside modules";
        }
    }
}
