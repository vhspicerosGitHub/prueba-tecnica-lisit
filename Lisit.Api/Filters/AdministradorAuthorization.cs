using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Lisit.Models;

namespace Lisit.Api.Filters {
    public class AdministradorAuthorization : Attribute, IAuthorizationFilter {
        public void OnAuthorization(AuthorizationFilterContext context) {
            // Your custom authorization logic here

            var user = context.HttpContext.User;
            if (!IsAuthorized(context.HttpContext.User)) {
                new AuthenticationException("Unauthorized");
            }
        }
        private bool IsAuthorized(ClaimsPrincipal user) {
            if (!user.Identity.IsAuthenticated)
                return false;

            var rol = user.Claims.ToList().FirstOrDefault(x => (x.Type == ClaimTypes.Role)).Value;
            var userId = user.Claims.ToList().FirstOrDefault(x => (x.Type == ClaimTypes.NameIdentifier)).Value;
            var email = user.Claims.ToList().FirstOrDefault(x => (x.Type == ClaimTypes.Name)).Value;

            if (Convert.ToInt16(rol) == (int)Roles.Admin)
                return true;

            return false;
        }
    }

}
