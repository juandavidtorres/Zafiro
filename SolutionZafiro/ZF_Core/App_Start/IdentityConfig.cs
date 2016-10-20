using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using ZF_Core.Models;

namespace ZF_Core
{
    public class IdentityConfig
    {
        public static void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ContextoIdentity>(ContextoIdentity.Crear);
            app.CreatePerOwinContext<GestionUsuarios>(GestionUsuarios.Crear);

            app.UseCookieAuthentication(new CookieAuthenticationOptions{ 
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath= new PathString("/Security/Login")
            });
        }
    }

 
}