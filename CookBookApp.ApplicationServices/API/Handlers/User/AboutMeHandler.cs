using CookBookApp.ApplicationServices.API.Domain.UserRoles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.User
{
    public class AboutMeHandler : IRequestHandler<AboutMeRequest, AboutMeResponse>
    {
        public async Task<AboutMeResponse> Handle(AboutMeRequest request, CancellationToken cancellationToken)
        {
            return new AboutMeResponse()
            {
                Data = request
            };
        }
    }
}
