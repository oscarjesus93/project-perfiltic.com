using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Entities
{
    public class Category
    {
        [Key]
        public int id_category { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The name field is required.")]
        public string name { get; set; }
    }
}
