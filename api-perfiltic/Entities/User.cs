using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Entities
{
    public class User
    {
        [Key]
        public int id_user { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The name field is required.")]
        public string name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "The email field is not a valid e-mail address.")]
        public string email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The password field is required.")]
        public string password { get; set; }

    }
}
