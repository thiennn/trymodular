using Microsoft.EntityFrameworkCore;

namespace Modular.Core
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
