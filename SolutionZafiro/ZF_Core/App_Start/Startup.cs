using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using ZF_Core.Models;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(ZF_Core.App_Start.Startup))]

namespace ZF_Core.App_Start
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
           
            app.CreatePerOwinContext<ContextoIdentity>(ContextoIdentity.Crear);
            app.CreatePerOwinContext<GestionUsuarios>(GestionUsuarios.Crear);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Security/Login")
            });

        }

    }
}
