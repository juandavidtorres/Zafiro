using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZF_Core.Models;
using System.Collections.Generic;
using System.Web.Security;
using System.Data;


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

        [AllowAnonymous]
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
                string txtCodigo = frmformulario["codenterprise"];
                txtCodigo = oDatos.ZFCore_RecuperarCodigoCompania(txtCodigo);

                Membership.CreateUser(txtusuario, txtClave, txtEmail);
                MembershipUser userInfo = Membership.GetUser(txtusuario);
                userInfo.IsApproved = false;
                Membership.UpdateUser(userInfo);
                oDatos.ZFCore_AsociarUsuarioCompania(userInfo.ProviderUserKey.ToString(), txtCodigo);
                var callbackUrl = Url.Action("ConfirmEmail", "Security", new { userId = userInfo.ProviderUserKey, code = txtCodigo },
                        protocol: Request.Url.Scheme);

                EmailService.SendMail("Por favor confirme su cuenta ingresando a este link: <a href=\""
                                                 + callbackUrl + "\">link</a>", oDatos.ZFCore_RecuperarParametro("CorreodeConfirmaciondeCuenta", txtCodigo), "Activacion de cuenta", txtEmail, oDatos.ZFCore_RecuperarParametro("ApiSendGrid", txtCodigo));


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
                MembershipUser Usuario = Membership.GetUser(userId, false);

                if (Usuario == null)
                {
                    ViewBag.Mensaje = "Hubo un problema ubicando sus crendenciales de usuario, por favor confirme nuevamente su cuenta";
                    ViewBag.Autorizado = 0;
                }
                else
                {
                    Usuario.IsApproved = true;
                    Membership.UpdateUser(Usuario);
                    ViewBag.Mensaje = "Su usuario fue confirmado correctamente, ahora el sistema lo llevara a la pagina de principal";
                    ViewBag.Autorizado = 1;
                }
            }
            catch (System.Exception ex)
            {

                ViewBag.Mensaje = "Error: " + ex.Message;
                ViewBag.Autorizado = 0;
            }
            return View();
        }

        [AllowAnonymous]      
        [HttpPost]  
        public ActionResult SendConfirmationHttp(FormCollection frmformulario)
        {

            try
            {
                if (frmformulario.Count > 0)
                {

                    string txtusuario = frmformulario["txtUser"];
                    string txtEmail = frmformulario["txtEmail"];
                    MembershipUser userInfo = Membership.GetUser(txtusuario);

                    if (userInfo.IsApproved)
                    {
                        ViewBag.Mensaje = "Su cuenta esta activa, sino recuerda su clave puede cambiar por la opcion de cambio de contraseña";
                        ViewBag.Autorizado = 0;
                        return View("SendConfirmation");
                    }
                    else
                    {

                        DataLayer.DataLayer oDatos = new DataLayer.DataLayer();
                        IDataReader oReader = oDatos.ZFCore_RecuperarCompaniaPorUsuario(userInfo.ProviderUserKey.ToString());
                        string txtCodigo = "";
                        while (oReader.Read())
                        {
                            txtCodigo = oReader["Codigo"].ToString();

                        }
                        oReader.Close();
                        if (string.IsNullOrEmpty(txtCodigo))
                        {
                            ViewBag.Mensaje = "Al parecer hubo un problema, su usuario no esta asociado a una compañia, por favor contacte a su administrador de sistema y reporte el caso con su nombre de usuario ";
                            ViewBag.Autorizado = 0;
                            return View("SendConfirmation");
                        }
                        var callbackUrl = Url.Action("ConfirmEmail", "Security", new { userId = userInfo.ProviderUserKey, code = txtCodigo },
                      protocol: Request.Url.Scheme);

                        EmailService.SendMail("Por favor confirme su cuenta ingresando a este link: <a href=\""
                                                         + callbackUrl + "\">link</a>", oDatos.ZFCore_RecuperarParametro("CorreodeConfirmaciondeCuenta", txtCodigo), "Activacion de cuenta", txtEmail, oDatos.ZFCore_RecuperarParametro("ApiSendGrid", txtCodigo));

                        ViewBag.Mensaje = "Se acaba de enviar un correo electronico a su cuenta de correo, por favor active su cuenta por medio del link que se le envio";
                        ViewBag.Autorizado = 1;
                        return View("SendConfirmation");
                    }

                }
                else
                {
                    ViewBag.Mensaje = "Datos invalidos, por favor complete los campos";
                    return View("SendConfirmation");
                }
            }
            catch (System.Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View("SendConfirmation");
        }

        public ActionResult SendConfirmation(FormCollection frmformulario)
        {         

            return View("SendConfirmation");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(FormCollection frmformulario)
        {
            string Mensaje = "";
            try
            {
                if (frmformulario.Count > 0)
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
                    else
                    {
                        MembershipUser Usuario = Membership.GetUser(txtusuario, false);
                        if (Usuario == null)
                        {
                            Mensaje = "El usuario " + txtusuario + " no existe la base de datos";
                        }
                        else
                        {
                            if (Usuario.IsApproved == false)
                            {
                                Mensaje = "El usuario no esta activo, realice la activacion de su cuenta por medio del email de confirmacion";
                            }
                            else
                            {
                                Mensaje = "Por favor verifique sus credenciales de ingreso al sitio, al parecer estan incorrectas";
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Mensaje = ex.Message;
            }
            ViewBag.Mensaje = Mensaje;
            return View("Login");
        }

    }


}