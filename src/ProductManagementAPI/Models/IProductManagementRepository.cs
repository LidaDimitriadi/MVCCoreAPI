using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAPI.Models
{
    public interface IProductManagementRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        bool AddNewProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<bool> SaveChangesAsync();
        bool SaveChanges();
        Task<bool> UpdateReviews(int id, Review review);
        //List<Review> GetReviewsByProductId(int id);
    }
}
