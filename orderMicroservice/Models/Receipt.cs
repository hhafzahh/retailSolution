using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace orderMicroservice.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public string productName { get; set; }

        public float amount { get; set; }

        public int CustomerId { get; set; }

        public string customerName { get; set; }

        public int CheckoutId { get; set; } //Foreign Key
        public Checkout checkout { get; set; } //Inverse Navigation Property
    }


}

