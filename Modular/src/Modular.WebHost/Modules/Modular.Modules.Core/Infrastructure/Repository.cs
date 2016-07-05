using Modular.Core.Domain;
using Modular.Core.Domain.Models;
using Modular.Modules.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.WebHost.Modules.Modular.Modules.Core.Infrastructure
{
    public class Repository<T> : RepositoryWithTypedId<T, long>, IRepository<T>
        where T : class, IEntityWithTypedId<long>
    {
        public Repository(ModularDbContext context) : base(context)
        {
        }
    }
}
