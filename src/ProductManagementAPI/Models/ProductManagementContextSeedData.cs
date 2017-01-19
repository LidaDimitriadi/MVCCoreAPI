using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAPI.Models
{
    public class ProductManagementContextSeedData
    {
        private ProductManagementContext _context;

        public ProductManagementContextSeedData(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if(!_context.Products.Any())
            {
                var lst = new List<Product>()
                {
                   new Product() {
                        Name = "A Garden Cart",
                        Code = "GDN - 0023",
                        ReleaseDate = Convert.ToDateTime("March 18, 2016"),
                        Description = "15 galon capacity rolling",
                        Price = (decimal)17.89,
                        Rating = (float)4.2,
                        ImgUrl = "img/garden-cart.png"
                    },
                    new Product() {
                        Name = "AB Hammer",
                        Code = "GDN - 0023",
                        ReleaseDate = Convert.ToDateTime("November 13, 2016"),
                        Description = "15 galon capacity rolling",
                        Price = (decimal)8.90,
                        Rating = (float)2.3,
                        ImgUrl = "img/rejon-Hammer.png"
                    },
                    new Product() {
                        Name = "ABC Saw",
                        Code = "TBX - 0022",
                        ReleaseDate = Convert.ToDateTime("November 16, 2016"),
                        Description = "15-inch steel blade hand saw",
                        Price = (decimal)49.90,
                        Rating = (float)2.8,
                        ImgUrl = "img/power-saw.png"
                    },
                    new Product() {
                        Name = "ABCD X - Box Controller",
                        Code = "GMC - 0071",
                        ReleaseDate = Convert.ToDateTime("November 17, 2016"),
                        Description = "Standard video game controller",
                        Price = (decimal)178.90,
                        Rating = (float)1.2,
                        ImgUrl = "img/control.png"
                    },
                    new Product() {
                        Name = "ABCDE Leaf Rake",
                        Code = "GDN - 0011",
                        ReleaseDate = Convert.ToDateTime("November 21, 2016"),
                        Description = "Leaf rake with 48-inch wooden handle",
                        Price = (decimal)19.95,
                        Rating = (float)3.2,
                        ImgUrl = "img/leaf-rake.png"
                    }
                };

                _context.Products.AddRange(lst);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
