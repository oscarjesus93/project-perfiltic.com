using api_perfiltic.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Utilities
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> pt_users { get; set; }
        public DbSet<Category> pt_category { get; set; }
        public DbSet<Gallery> pt_gallery { get; set; }
        public DbSet<Product> pt_products { get; set; }
        public DbSet<Subcategory> pt_subcategory { get; set; }

    }
}
