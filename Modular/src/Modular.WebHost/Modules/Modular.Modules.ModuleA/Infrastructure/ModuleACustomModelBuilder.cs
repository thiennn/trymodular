using Modular.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modular.Modules.ModuleA.Models;

namespace Modular.Modules.ModuleA.Infrastructure
{
    public class ModuleACustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>()
                .Property(x => x.Name).HasColumnName("TestName");
        }
    }
}
