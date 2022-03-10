using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cartMicroservice.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public string productName { get; set; }
        public int productId { get; set; }
        public int ShoppingCartId { get; set; }
        [JsonIgnore]

        public ShoppingCart ShoppingCart { get; set; }
    }
}

