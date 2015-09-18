using System.Collections.Generic;
using Fleetmatics.Domain;
using Fleetmatics.Domain.Contracts;
using Fleetmatics.Service.Contracts;

namespace Fleetmatics.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public ICollection<Product> GetProducts()
        {
            return _productRepository.Get();
        }
    }
}
