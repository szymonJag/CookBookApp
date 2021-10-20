
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CookBookApp.ApplicationServices.API.Domain
{
    public abstract class RequestBase
    {
        public string AuthenticatedUserName { get; set; }
        public string UserRole { get; set; }
    }
}
