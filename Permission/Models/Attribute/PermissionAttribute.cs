using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Permission.Models.Attribute
{    
    public class PermissionAttribute : ActionFilterAttribute
    {
        public int Id { get; set; }


        public PermissionAttribute(int Id)
        {
            this.Id = Id;

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 取得Cookies
            var claims = HttpContext.Current.User.Identity.Claims().Where(w => w.Type == nameof(UserPermission)).Single();
            // 轉型
            List<UserPermission> liUserPermission = JsonConvert.DeserializeObject<List<UserPermission>>(claims.Value);

            // 檢查是否具有權限
            bool isPermission = ServiceId(liUserPermission);

            // 如果沒有權限，直接寫入回傳結果
            if (!isPermission)
                filterContext.Result = new JsonResult { Data = "沒有權限", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
            base.OnActionExecuting(filterContext);
        }

        private bool ServiceId(List<UserPermission> liUserPermission)
        {
            // 比對權限
            foreach (UserPermission userPermission in liUserPermission)
            {
                if (userPermission.Id == Id)
                    return true;
            }
            return false;
        }
    }
}