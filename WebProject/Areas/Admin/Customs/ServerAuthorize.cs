using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace WebProject.Areas.Admin.Customs {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ServerAuthorize : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext == null) {
                throw new ArgumentNullException(nameof(filterContext));
            }
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated) {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "AdminLogin" },
                    { "to", filterContext.HttpContext.Request.Path}
                });
            }
        }
    }

}
