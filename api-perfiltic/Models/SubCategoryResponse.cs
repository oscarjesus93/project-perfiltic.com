using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Models
{
    public class SubCategoryResponse
    {
        public int id_subcategory { get; set; }
        public string description { get; set; }
        public CategoryResponse category { get; set; }
    }
}
