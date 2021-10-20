using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.FoodTypes
{
    public class GetFoodTypeByIdRequest : RequestBase, IRequest<GetFoodTypeByIdResponse>
    {
        public int FoodTypeId { get; set; }
    }
}
