using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductServices
    {
        Task<Product> GetProduct(Guid? id);
        Task<List<Product>> GetAllProducts();
    }
}
