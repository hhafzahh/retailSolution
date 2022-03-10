using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productMicroservice.Classes
{
    public class ProductQueryParameters
    {
        public int catId { get; set; }
        public float? MinPrice { get; set; }
        public float? MaxPrice { get; set; }


    }
}
