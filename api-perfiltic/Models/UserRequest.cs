using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Models
{
    public class UserRequest
    {

        public string name { get; set; }
        public string email { get; set; }
        public string confirEmail { get; set; }
        public string password { get; set; }
        public string confirPassword { get; set; }
    }
}
