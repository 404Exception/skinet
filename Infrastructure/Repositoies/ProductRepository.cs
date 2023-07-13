using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositoies
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dataContext.Products.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
