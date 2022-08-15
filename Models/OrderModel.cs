using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCuisine.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderItems { get; set; }
        public decimal OrderTotal { get; set; }
        public string Orderstatus { get; set; }
    }
}
