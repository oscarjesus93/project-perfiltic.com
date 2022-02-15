using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Entities
{
    public class Subcategory
    {
        [Key]
        public int id_subcategory { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "The description field is required.")]
        public string description { get; set; }

        [Required(ErrorMessage = "you must select a category")]
        public int id_category { get; set; }
    }
}
