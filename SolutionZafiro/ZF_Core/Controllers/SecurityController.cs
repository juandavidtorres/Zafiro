using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZF_Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace ZF_Core.Content
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        private void CreateUser(FormCollection frmformulario)
        {
            ModelZafiro context = new ModelZafiro();
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser();
                user.Email= frmformulario["email"];
                user.EmailConfirmed = true;
                user.UserName= frmformulario["email"];
                var OutputUser = UserManager.Create(user, frmformulario["password"]);

            }
           
        }


        [HttpPost]
        public ActionResult LogIn(FormCollection frmformulario)
        {

            string txtusuario = "";
            string txtclave = "";

            txtusuario= frmformulario["username"];
            txtclave= frmformulario["password"];
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            // Don't do this in production!
            if (txtusuario == "admin@admin.com" && txtclave == "admin@admin.com")
            {
                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, "Ben"),
                new Claim(ClaimTypes.Email, "a@b.com"),
                new Claim(ClaimTypes.Country, "England")
            },
                        "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(""));
            }      
            return View();
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Alumnos", "BackOffice");
            }

            return returnUrl;
        }
    }
}