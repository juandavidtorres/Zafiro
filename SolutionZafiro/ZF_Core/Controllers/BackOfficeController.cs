using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Clases()
        {
            return View();
        }




    }

}