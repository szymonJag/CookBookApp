using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Models
{
    public class Ingredient
    {
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Value { get; set; }
    }
}
