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
            ViewBag.Title = "Login";
            return View();
        }





        public ActionResult Register()
        {
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public JsonResult CreateUser(FormCollection frmformulario)
        {
            JsonResult Respuesta = null;
            try
            {
                DataLayer.DataLayer oDatos = new DataLayer.DataLayer();
                string txtusuario = frmformulario["username"];
                string txtClave = frmformulario["password"];
                string txtEmail = frmformulario["email"];
                string txtCodigo= frmformulario["codenterprise"];
                txtCodigo = oDatos.ZFCore_RecuperarCodigoCompania(txtCodigo);               

                Membership.CreateUser(txtusuario, txtClave, txtEmail);
                MembershipUser userInfo = Membership.GetUser(txtusuario);
                userInfo.IsApproved = false;
                Membership.UpdateUser(userInfo);
                var callbackUrl = Url.Action("ConfirmEmail", "Security", new { userId = userInfo.ProviderUserKey,code=txtCodigo },
                        protocol: Request.Url.Scheme);

                EmailService.SendMail("Por favor confirme su cuenta ingresando a este link: <a href=\""
                                                 + callbackUrl + "\">link</a>", oDatos.ZFCore_RecuperarParametro("CorreodeConfirmaciondeCuenta",txtCodigo),"Activacion de cuenta" , txtEmail, oDatos.ZFCore_RecuperarParametro("ApiSendGrid",txtCodigo));


               Respuesta = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new ZF_Core.Models.RespuestaProceso() { Autorizado = true, Mensaje = "Operacion exitosa, usuario creado correctamente, se ha enviado un correo a su email para confirmar su cuenta" }
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
               MembershipUser Usuario= Membership.GetUser(userId, false);
                Usuario.IsApproved = true;
                Membership.UpdateUser(Usuario);

            }
            catch (System.Exception)
            {

                
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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