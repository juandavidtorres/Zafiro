using System.Web.Mvc;


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