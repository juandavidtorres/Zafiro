using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZF_Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

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


        private GestionUsuarios ObtenerGestionUsuarios()
        {
            return HttpContext.GetOwinContext().GetUserManager<GestionUsuarios>();
        }

      
       

        private void registrarErrores(IdentityResult resultado)
        {
            if (resultado != null)
            {
                foreach (string detalleError in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, detalleError);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<JsonResult> CreateUser(FormCollection frmformulario)
        {
            JsonResult Respuesta = null;
            try
            {
                ContextoIdentity context = new ContextoIdentity();
                if (ModelState.IsValid)
                {
                    Usuario user = new Usuario();                  
                    user.Email = frmformulario["email"];
                    user.UserName = frmformulario["username"];
                    user.EmailConfirmed = true;
                    GestionUsuarios gestionUsuarios = ObtenerGestionUsuarios();
                    IdentityResult OutputUser = await gestionUsuarios.CreateAsync(user, frmformulario["password"]);                   
                    if (!OutputUser.Succeeded)
                    {
                        foreach (string item in OutputUser.Errors)
                        {
                            Respuesta = new JsonResult()
                            {
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                                Data = new RespuestaProceso() { Autorizado = true, Mensaje = item }
                            };
                        }

                    }
                    else
                    {
                        EmailService.SendMail("Prueba", "jdtorres31@gmail.com", "Prueba", "jdtorres31@gmail.com", "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");

                        Respuesta = new JsonResult()
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            Data = new ZF_Core.Models.RespuestaProceso() { Autorizado = true, Mensaje = "Operacion exitosa, usuario creado correctamente" }
                        };

                    }
                }

            }
            catch (System.Exception ex)
            {
                Respuesta = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new ZF_Core.Models.RespuestaProceso() { Autorizado = true, Mensaje = ex.Message }
                };

            }
            
           
            return Respuesta;
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