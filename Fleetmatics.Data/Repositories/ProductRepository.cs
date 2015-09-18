using System.Collections.Generic;
using System.Threading.Tasks;
using Fleetmatics.Domain;
using Fleetmatics.Domain.Contracts;

namespace Fleetmatics.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ICollection<Product> Get()
        {
            var lstProducts = new List<Product>()
            {
                new Product(){Id = 1, Description = "Soap", Price = 1},
                new Product(){Id = 2, Description = "Sugar", Price = 2},
                new Product(){Id = 1, Description = "Rice", Price = 1.5},
                new Product(){Id = 1, Description = "Apple", Price = 2},
                new Product(){Id = 1, Description = "Onion", Price = 1},
            };

            return lstProducts;
        }

        public Task<Product> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveOrUpdate(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
