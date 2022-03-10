using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cartMicroservice.Models;

namespace cartMicroservice.Data
{
    public class cartMicroserviceContext : DbContext
    {
        public cartMicroserviceContext (DbContextOptions<cartMicroserviceContext> options)
            : base(options)
        {
        }

        public DbSet<cartMicroservice.Models.CartItem> CartItem { get; set; }

        public DbSet<cartMicroservice.Models.ShoppingCart> ShoppingCart { get; set; }
    }
}
