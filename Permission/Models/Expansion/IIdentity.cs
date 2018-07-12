using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;


public static class IIdentity
{
    public static IEnumerable<Claim> Claims(this System.Security.Principal.IIdentity identity)
    {
        var claimsIdentity = (identity as ClaimsIdentity);
        return claimsIdentity.Claims;
    }
}
