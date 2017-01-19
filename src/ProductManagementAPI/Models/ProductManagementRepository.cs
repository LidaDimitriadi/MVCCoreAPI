using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAPI.Models
{
    public class ProductManagementRepository : IProductManagementRepository
    {
        private ProductManagementContext _context;

        public ProductManagementRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public bool AddNewProduct(Product product)
        {
            _context.Products.Add(product);

            return SaveChanges();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var entity = GetProductById(id);
            _context.Products.Remove(entity);


            return await SaveChangesAsync();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include(x => x.Reviews).FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateReviews(int id, Review review)
        {
            var entity = _context.Products.FirstOrDefault(x => x.Id == id);

            if(entity != null)
            {
                if(entity.Reviews == null)
                {
                    entity.Reviews = new List<Review>();
                }
                entity.Reviews.Add(review);
                _context.Add(review);
            }
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
