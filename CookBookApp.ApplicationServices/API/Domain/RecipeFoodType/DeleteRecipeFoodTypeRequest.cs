using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.RecipeFoodType
{
    public class DeleteRecipeFoodTypeRequest : RequestBase, IRequest<DeleteRecipeFoodTypeResponse>
    {
        public int RecipeFoodTypeId { get; set; }
    }
}
