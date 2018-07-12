using Permission.Models.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Permission.Controllers
{
    [Permission(20)]
    public class IndexController : BaseController
    {
        // GET: Index
        [Permission(10)]
        public ActionResult Index()
        {
            return View();
        }
    }
}