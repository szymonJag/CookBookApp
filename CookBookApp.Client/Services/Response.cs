using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Client.Services
{
    public class Response<T>
    {
        public T Data { get; set; }
    }
}
