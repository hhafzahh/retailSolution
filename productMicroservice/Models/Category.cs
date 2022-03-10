using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productMicroservice.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string categoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
