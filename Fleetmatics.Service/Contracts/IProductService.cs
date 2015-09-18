using System.Collections.Generic;
using Fleetmatics.Domain;

namespace Fleetmatics.Service.Contracts
{
    public interface IProductService
    {
       ICollection<Product> GetProducts();
    }
}
