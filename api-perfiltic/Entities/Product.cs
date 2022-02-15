using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Entities
{
    public class Product
    {
        [Key]
        public int id_product { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "The name field is required.")]
        public string name { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "The description field is required.")]
        public string description { get; set; }

        [Required(ErrorMessage = "The weigth field is required.")]
        public double weight { get; set; }

        [Required(ErrorMessage = "The price field is required.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "You must select a sub category.")]
        public int id_subcategory { get; set; }

        
        [StringLength(10)]
        [Required(ErrorMessage = "The currency field is required.")]
        public string currency { get; set; }

    }
}
