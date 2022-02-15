using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Entities
{
    public class Gallery
    {
        [Key]
        public int id_gallery { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The photo field is required.")]
        public string photo { get; set; }

        [Required(ErrorMessage = "The product is required.")]
        public int id_product { get; set; }
    }
}
