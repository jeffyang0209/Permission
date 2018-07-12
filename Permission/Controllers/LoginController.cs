using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Permission.Models;
using Permission.Models.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Permission.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult In()
        {
            // 增加權限列表
            List<UserPermission> liUserPeermission = new List<UserPermission>();
            liUserPeermission.Add(new UserPermission { Id = 1, Name = "A" });
            liUserPeermission.Add(new UserPermission { Id = 2, Name = "B" });
            liUserPeermission.Add(new UserPermission { Id = 3, Name = "C" });
            liUserPeermission.Add(new UserPermission { Id = 4, Name = "D" });

            List<Claim> liClaim = new List<Claim>();
            // claim裡面增加權限的資料
            liClaim.Add(new Claim(nameof(UserPermission), JsonConvert.SerializeObject(liUserPeermission)));

            // 寫入Cookies
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(liClaim, "Boyu");

            
            HttpContext.GetOwinContext().Authentication.SignIn(claimsIdentity);
            AuthenticationProperties s = new AuthenticationProperties();

            return Json(new { result = "OK" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAuth()
        {
            // 取得登入使用者資料的方式，此段寫法需再進行封裝
            var Claims = HttpContext.User.Identity.Claims();
            string x = Claims.Where(w => w.Type == "1").First().Value;
            return Json(new { result = "OK" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Out()
        {
            // 登出
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Json(new { result = "OUT" }, JsonRequestBehavior.AllowGet);
        }
    }
}