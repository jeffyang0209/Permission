using Permission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

public class BackendUserAuthorizeAttribute : AuthorizeAttribute
{
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            // 如果尚未登入則導轉
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                     {
                                                                         {"controller", "Login"},
                                                                         {"action", "Out"}
                                                                     });            
        }
    }
}
