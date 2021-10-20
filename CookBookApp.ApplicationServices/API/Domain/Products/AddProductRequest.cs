using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain
{
    public class AddProductRequest : RequestBase, IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public int Kcal { get; set; }
        public int ProductTypeId { get; set; }
    }
}
