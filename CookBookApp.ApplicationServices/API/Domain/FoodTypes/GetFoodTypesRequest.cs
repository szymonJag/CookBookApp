using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.FoodTypes
{
    public class GetFoodTypesRequest : RequestBase, IRequest<GetFoodTypesResponse>
    {
    }
}
