using Modular.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.Modules.ModuleA.Models
{
    public class Sample : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
