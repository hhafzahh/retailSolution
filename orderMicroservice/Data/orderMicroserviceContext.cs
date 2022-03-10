using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using orderMicroservice.Models;

namespace orderMicroservice.Data
{
    public class orderMicroserviceContext : DbContext
    {
        public orderMicroserviceContext (DbContextOptions<orderMicroserviceContext> options)
            : base(options)
        {
        }

        public DbSet<orderMicroservice.Models.Checkout> Checkout { get; set; }

        public DbSet<orderMicroservice.Models.Receipt> Receipt { get; set; }
    }
}
