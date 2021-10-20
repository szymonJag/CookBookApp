using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Client.Models
{
    public class User : ModelBase
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string AuthData { get; set; }
    }
}
