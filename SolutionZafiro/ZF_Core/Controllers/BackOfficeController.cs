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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddStudent(FormCollection frmformulario)//(string txtcedula,string txtnombre, string txtapellido,string txtfecha, string txttelefono,string txtdireccion)
        {
            JsonResult Respuesta;
            try
            {
                
               //// ZF_Core.Models.Estudiante Student = new Models.Estudiante();
               // Student.Apellido = frmformulario["txtapellido"];
               // Student.Nombre = frmformulario["txtnombre"];
               // Student.Nuip = frmformulario["txtcedula"];
               // Student.Telefono = frmformulario["txttelefono"];

               //// db.Estudiante.AddOrUpdate(Student);
               // db.SaveChanges();
                Respuesta= new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new ZF_Core.Models.RespuestaProceso() { Autorizado = true, Mensaje = "Operacion exitosa, estudiante creado correctamente" }
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