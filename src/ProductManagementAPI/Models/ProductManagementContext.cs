using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementAPI.Models
{
    public class ProductManagementContext : DbContext
    {
        private IConfigurationRoot _config;
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }


        public ProductManagementContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["DbConnectionString"]);
        }
    }
}
