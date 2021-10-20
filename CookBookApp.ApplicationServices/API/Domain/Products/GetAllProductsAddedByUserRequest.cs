﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Products
{
    public class GetAllProductsAddedByUserRequest : RequestBase, IRequest<GetAllProductsAddedByUserResponse>
    {
        public string Username { get; set; }
    }
}
