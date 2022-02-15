using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Models.Auth
{
    public class Auth
    {
        public class Request
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public class Response
        {
            public string mensaje { get; set; }
            public string token { get; set; }
        }
    }
}
