using System.Web.Mvc;
using System.Data.Entity.Migrations;

namespace ZF_Core.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET: BackOffice
        public ActionResult Profesores()
        {
            return View();
        }
        public ActionResult Alumnos()
        {
            ViewBag.Titulo = "Alumnos";
            ZF_Core.Models.ModelZafiro db = new Models.ModelZafiro();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddStudent(FormCollection formCollection)//(string txtcedula,string txtnombre, string txtapellido,string txtfecha, string txttelefono,string txtdireccion)
        {
            JsonResult Respuesta;
            try
            {
                ZF_Core.Models.ModelZafiro db = new Models.ModelZafiro();
                // db.Estudiante.AddOrUpdate()
                Respuesta= new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new ZF_Core.Models.RespuestaProceso() { Autorizado = true, Mensaje = "Autorizado" }
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
        public ActionResult Clases()
        {
            return View();
        }




    }

}