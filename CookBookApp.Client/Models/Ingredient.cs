using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Client.Models
{
    public class Ingredient : ModelBase
    {
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Value { get; set; }
    }
}
