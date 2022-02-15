using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Models
{
    public class ProductResponse
    {
        public int id_product { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double weight { get; set; }
        public decimal price { get; set; }
        public SubCategoryResponse subCategory { get; set; }
        public string currency { get; set; }
    }
}
