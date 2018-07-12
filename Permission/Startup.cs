using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(Permission.Startup))]
namespace Permission
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                ExpireTimeSpan = TimeSpan.FromHours(1),
                //作為辨識的的Cookie屬性
                AuthenticationType = "Boyu",
                //如果無權限存取401 最後導頁的位置
                //LoginPath = new PathString("/Home/index")
            });
            ConfigureAuth(app);
        }
    }
}
