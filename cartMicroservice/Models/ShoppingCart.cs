using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cartMicroservice.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string username { get; set; }
        public float totalPrice { get; set; }
        public string cartStatus { get; set; }
       
        public string timestamp { get; set; } 
      
        public ICollection<CartItem> CartItems { get; set; }

       public DateTime CreatedDate { get; set; }
       public DateTime ModifiedDate { get; set; }

       
    }
}
