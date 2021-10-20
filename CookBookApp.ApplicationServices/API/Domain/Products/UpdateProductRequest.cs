using CookBookApp.ApplicationServices.API.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Products
{
    public class UpdateProductRequest : RequestBase, IRequest<UpdateProductResponse>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Kcal { get; set; }
        public int ProductTypeId { get; set; }
    }
}
