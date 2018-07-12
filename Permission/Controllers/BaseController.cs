using System.Collections.Generic;
using System.Web.Mvc;

namespace Permission.Controllers
{
    [BackendUserAuthorize]
    public class BaseController : Controller
    {
    }
}