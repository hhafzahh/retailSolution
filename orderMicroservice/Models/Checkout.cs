using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderMicroservice.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public string username { get; set; }
        public int totalPrice { get; set; }

        public string cardNumber { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string cvc { get; set; }
        
        public int CustomerId { get; set; }
        public int ShoppingCartId { get; set; }
        public string paymentType { get; set; }
        public Receipt receipt { get;set;} //Navigation Property
}
}
