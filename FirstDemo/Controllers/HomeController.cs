using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstDemo.Controllers
{
    public class HomeController : Controller
    {
        private IAnimal _animal { get; set; }

        public HomeController(IAnimal animal)
        {
            _animal = animal;
        }

        public ActionResult Index()
        {
            var kk = _animal.SayHello();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}