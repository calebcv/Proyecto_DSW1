using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_DSW1.Models;

namespace Proyecto_DSW1.Controllers
{
    public class ConsultaController : Controller
    {
        BD_DSW1Entities db = new BD_DSW1Entities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductoListar()
        {
            var lista = from p in db.usp_ProductoListar() select p;
            return View(lista.ToList());
        }
        public ActionResult CategoriaListar(string nom_cat)
        {
            if (nom_cat == null) nom_cat = String.Empty;
            ViewBag.nom_cat = nom_cat;
            var lista = from p in db.usp_CategoriaNombre(nom_cat) select p;
            return View(lista.ToList());
        }
        public ActionResult PedidosCategoria(string nom_cat)
        {
            if (nom_cat == null) nom_cat = string.Empty;
            ViewBag.Categoria = new SelectList(db.Categoria.ToList(), "idCategoria", "nom_cat", nom_cat);
            var lista = from p in db.Categoria
                        where p.nom_cat.Equals(nom_cat)
                        select p;
            return View(lista.ToList());
        }
    }
}