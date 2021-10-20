using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Units
{
    public class DeleteUnitRequest : RequestBase, IRequest<DeleteUnitResponse>
    {
        public int UnitId { get; set; }
    }
}
