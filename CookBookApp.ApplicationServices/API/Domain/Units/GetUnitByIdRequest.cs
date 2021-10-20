using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Units
{
    public class GetUnitByIdRequest : RequestBase, IRequest<GetUnitByIdResponse>
    {
        public int UnitId { get; set; }
    }
}
