using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZF_Core.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Home()
        {
            return View();
        }
    }
}