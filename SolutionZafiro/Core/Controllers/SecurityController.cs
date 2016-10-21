using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZF_Core.Models;
using System.Collections.Generic;
using System.Web.Security;

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





        public ActionResult Register()
        {
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateUser(FormCollection frmformulario)
        {
            JsonResult Respuesta = null;
            try
            {
                string txtusuario = frmformulario["username"];
                string txtClave = frmformulario["password"];
                string txtEmail = frmformulario["email"];
                Membership.CreateUser(txtusuario, txtClave, txtEmail);
                MembershipUser userInfo = Membership.GetUser(txtusuario);                

                var callbackUrl = Url.Action("ConfirmEmail", "Security", new { userId = userInfo.ProviderUserKey },
                        protocol: Request.Url.Scheme);

                EmailService.SendMail("Por favor confirme su cuenta ingresando a este link: <a href=\""
                                                 + callbackUrl + "\">link</a>", "jdtorres31@gmail.com","Activacion de cuenta" , "jdtorres31@gmail.com", "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");


               Respuesta = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new ZF_Core.Models.RespuestaProceso() { Autorizado = true, Mensaje = "Operacion exitosa, usuario creado correctamente" }
                };               

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
        public ActionResult ConfirmEmail(string userId, string code)
        {
            try
            {
                //GestionUsuarios gestionUsuarios = ObtenerGestionUsuarios();                
                //var provider = new DpapiDataProtectionProvider("Zafiro");
                //gestionUsuarios.UserTokenProvider = new DataProtectorTokenProvider<Usuario, string>(provider.Create("UserToken"))as IUserTokenProvider<Usuario, string>;
                //IdentityResult OutputUser = gestionUsuarios.ConfirmEmail(userId, code);

                //if (OutputUser.Succeeded)
                //{
                //    ViewBag.MensajeConfirmacion = "Registro existoso, acontinuacion sera redireccionado a la pagina de inicio de session ";                   
                //}
                //else
                //{
                //    foreach (string item in OutputUser.Errors)
                //    {
                //        ViewBag.MensajeConfirmacion = item;
                //    }
                //}

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
            JsonResult Respuesta = null;
            try
            {
                string txtusuario = frmformulario["username"];
                string txtclave = frmformulario["password"];
                if (Membership.ValidateUser(txtusuario, txtclave))
                {
                    string URL = "";
                    if (Roles.IsUserInRole(txtusuario, "Estudiante"))
                        URL = Url.Action("Home", "Student");
                    else if (Roles.IsUserInRole(txtusuario, "Profesor"))
                        URL = Url.Action("BackOffice", "Profesores");
                    Redirect(URL);

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