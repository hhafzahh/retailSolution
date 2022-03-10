using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userMicroservice.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public string profilePicture { get; set; }
        public string address { get; set; }
        public string role { get; set; }
    }
}
