using Modular.Core.Domain.Models;

namespace Modular.Modules.Core.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
