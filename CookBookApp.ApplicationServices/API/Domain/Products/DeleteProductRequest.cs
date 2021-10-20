using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain
{
    public class DeleteProductRequest : RequestBase, IRequest<DeleteProductResponse>
    {
        public int ProductId { get; set; }
    }
}
