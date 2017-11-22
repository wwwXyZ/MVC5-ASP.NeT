using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult present(String id = "0")
        {
            var number = Int32.Parse(id);
            switch(number)
            {
                case 3:
                    RedirectToAction("Index", "Home");
                    break;
            }
            ViewBag.Number = number;
            return View();
        }
    }
}