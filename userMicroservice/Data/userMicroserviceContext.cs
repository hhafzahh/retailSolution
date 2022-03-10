using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using userMicroservice.Models;

namespace userMicroservice.Data
{
    public class userMicroserviceContext : DbContext
    {
        public userMicroserviceContext (DbContextOptions<userMicroserviceContext> options)
            : base(options)
        {
        }

        public DbSet<userMicroservice.Models.Customer> Customer { get; set; }
    }
}
