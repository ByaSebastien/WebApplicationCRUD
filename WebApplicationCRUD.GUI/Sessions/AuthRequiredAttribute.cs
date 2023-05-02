using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCRUD.IL.Sessions
{
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter)) { }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        private SessionManager session;

        public AuthRequiredFilter(SessionManager session)
        {
            this.session = session;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (session.CurrentUser is null)
            {
                context.Result = new RedirectToRouteResult(new { action = "Login", controller = "Member" });
            }
        }
    }
}
