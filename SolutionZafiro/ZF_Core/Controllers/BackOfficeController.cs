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
        public ActionResult AddStudent(string txtcedula,string txtnombre, string txtapellido,string txtfecha, string txttelefono,string txtdireccion)
        {
            ViewBag.Titulo = "Alumnos";
            ZF_Core.Models.ModelZafiro db = new Models.ModelZafiro();

            return View();
        }
        public ActionResult Clases()
        {
            return View();
        }




    }

}