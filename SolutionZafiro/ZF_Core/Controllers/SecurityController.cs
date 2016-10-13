using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZF_Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security;

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


        /// <summary>
        /// Obtiene el contexto de seguridad para ASP.NET Identity, con la instancia de esta clase se pueden crear los usuarios y todo el manejo de la cuenta de usuario
        /// , es elpunto de inicio de la seguridad de la aplicacion
        /// </summary>
        /// <returns></returns>
        private GestionUsuarios ObtenerGestionUsuarios()
        {
            return HttpContext.GetOwinContext().GetUserManager<GestionUsuarios>();
        }

        public ActionResult Register()
        {
            return View();
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
                Usuario user = new Usuario();
                GestionUsuarios gestionUsuarios = ObtenerGestionUsuarios();                
                if (ModelState.IsValid)
                {

                    user.Email = frmformulario["email"];
                    user.UserName = frmformulario["username"];
                    user.EmailConfirmed = false;
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
                        var provider = new DpapiDataProtectionProvider("Zafiro");
                        gestionUsuarios.UserTokenProvider = new DataProtectorTokenProvider<Usuario, string>(provider.Create("UserToken"))
        as IUserTokenProvider<Usuario, string>;
                        var code = await gestionUsuarios.GenerateEmailConfirmationTokenAsync(user.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Security", new { userId = user.Id, code = code },
                protocol: Request.Url.Scheme);


                        EmailService.SendMail("Por favor confirme su cuenta ingresando a este link: <a href=\""
                                               + callbackUrl + "\">link</a>", "jdtorres31@gmail.com","Activacion de cuenta" , "jdtorres31@gmail.com", "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");

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
                    Data = new ZF_Core.Models.RespuestaProceso() { Autorizado = false, Mensaje = ex.Message }
                };

            }


            return Respuesta;
        }

        [AllowAnonymous]
        public ActionResult ConfirmEmail(string userId,string code)
        {
            try
            {
                GestionUsuarios gestionUsuarios = ObtenerGestionUsuarios();                
                var provider = new DpapiDataProtectionProvider("Zafiro");
                gestionUsuarios.UserTokenProvider = new DataProtectorTokenProvider<Usuario, string>(provider.Create("UserToken"))as IUserTokenProvider<Usuario, string>;
                IdentityResult OutputUser = gestionUsuarios.ConfirmEmail(userId, code);

                if (OutputUser.Succeeded)
                {
                    ViewBag.MensajeConfirmacion = "Registro existoso, acontinuacion sera redireccionado a la pagina de inicio de session ";                   
                }
                else
                {
                    foreach (string item in OutputUser.Errors)
                    {
                        ViewBag.MensajeConfirmacion = item;
                    }
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(FormCollection frmformulario)
        {

            string txtusuario = "";
            string txtclave = "";

            txtusuario = frmformulario["username"];
            txtclave = frmformulario["password"];
            if (!ModelState.IsValid)
            {
                return View();
            }

            GestionUsuarios gestionUsuarios = ObtenerGestionUsuarios();
            var user = gestionUsuarios.FindAsync(txtusuario, txtclave);

            if (user != null)
            {
                var AutheticationManager = HttpContext.GetOwinContext().Authentication;
                AutheticationManager.SignOut();
                var result = gestionUsuarios.

            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
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