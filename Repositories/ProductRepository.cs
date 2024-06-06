using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Shop214662124Context _context;
        public ProductRepository(Shop214662124Context shop214662124Context)
        {
            _context = shop214662124Context;
        }

        public async Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, int?[] categoryIds, string? productName)
        {
            var query = _context.Products.Where(product =>
                (minPrice == null ? (true) : (product.Price >= minPrice))
                && (maxPrice == null ? (true) : (product.Price <= maxPrice))
                && (productName == null ? (true) : (product.ProductName.Contains(productName)))
                && ((categoryIds.Length == 0 || categoryIds[0] == null) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);

            List<Product> products = await query.ToListAsync();
            return products;
        }


        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
} 
