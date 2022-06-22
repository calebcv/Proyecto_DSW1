using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_DSW1.Models;
using Proyecto_DSW1.Permisos;

namespace Proyecto_DSW1.Controllers
{
    [ValidarSesion]
    public class HomeController : Controller
    {
        BD_DSW1Entities db = new BD_DSW1Entities();
        public ActionResult Index()
        {
            return View(db.Producto.ToList().OrderBy(x => x.des_prod));
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