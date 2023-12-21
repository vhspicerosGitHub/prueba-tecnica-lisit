using System.Security.Claims;

namespace Lisit.Api.Utils {
    public static class ContextUtil {
        public static int GetConnectedUserId(this HttpContext httpContext) {
            var user = httpContext.User;
            var userId = Convert.ToInt16(user.Claims.ToList().FirstOrDefault(x => (x.Type == ClaimTypes.NameIdentifier)).Value);
            return userId;
        }
    }
}
