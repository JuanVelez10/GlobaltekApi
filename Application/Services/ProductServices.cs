using Application.Contracts.Persistence;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public async Task<Product> GetProduct(Guid? id)
        {
            return productRepository.Get(id);
        }
    }
}
