using System.Collections.Generic;
using System.Web.Mvc;

namespace Permission.Controllers
{
    // 自製驗證方式
    [BackendUserAuthorize]
    public class BaseController : Controller
    {
    }
}