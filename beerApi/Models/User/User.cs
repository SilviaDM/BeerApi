using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerApi.Models.User
{
    public class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}