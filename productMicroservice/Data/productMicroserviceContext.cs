using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using productMicroservice.Models;

namespace productMicroservice.Data
{
    public class productMicroserviceContext : DbContext
    {
        public productMicroserviceContext (DbContextOptions<productMicroserviceContext> options)
            : base(options)
        {
        }

        public DbSet<productMicroservice.Models.Category> Category { get; set; }

        public DbSet<productMicroservice.Models.Product> Product { get; set; }
    }
}
