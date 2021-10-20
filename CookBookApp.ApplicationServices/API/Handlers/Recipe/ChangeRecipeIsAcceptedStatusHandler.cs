using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Recipes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Recipe;
using CookBookApp.DataAccess.CQRS.Queries.Recipe;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Recipe
{
    public class ChangeRecipeIsAcceptedStatusHandler : IRequestHandler<ChangeRecipeIsAcceptedStatusRequest, ChangeRecipeIsAcceptedStatusResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public ChangeRecipeIsAcceptedStatusHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<ChangeRecipeIsAcceptedStatusResponse> Handle(ChangeRecipeIsAcceptedStatusRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new ChangeRecipeIsAcceptedStatusResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetRecipeByIdQuery()
            {
                RecipeId = request.RecipeId
            };
            var recipe = this.queryExecutor.Execute(query).Result;

            //jesli nie jest zaakceptowane to akceptuje a jesli jest zaakceptowane to odakceptuje
            recipe.IsAcceptedByAdmin = recipe.IsAcceptedByAdmin ? recipe.IsAcceptedByAdmin = false : recipe.IsAcceptedByAdmin = true;

            var command = new UpdateRecipeCommand()
            {
                Parameter = recipe
            };

            return new ChangeRecipeIsAcceptedStatusResponse()
            {
                Data = this.mapper.Map<Domain.Models.Recipe>(recipe)
            };
        }
    }
}
