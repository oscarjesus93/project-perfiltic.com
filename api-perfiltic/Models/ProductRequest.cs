using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Models
{
    public class ProductRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public double weight { get; set; }
        public decimal price { get; set; }
        public int id_subcategory { get; set; }
        public string currency { get; set; }

    }
}
