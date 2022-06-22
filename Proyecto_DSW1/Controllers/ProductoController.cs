using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;

using Proyecto_DSW1.Models;
using System.Web.Helpers;
//using System.Data.Entity;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Proyecto_DSW1.Permisos;

namespace Proyecto_DSW1.Controllers
{
    [ValidarSesion]
    public class ProductoController : Controller
    {
        // GET: Producto
        BD_DSW1Entities db = new BD_DSW1Entities();
        public ActionResult Index()
        {
            return View(db.Producto.ToList());
        }

        public ActionResult IndexCarrito()
        {
            return View(db.Producto.ToList().OrderBy(x => x.des_prod));
        }

        /*
        public ActionResult getImage(int id)
        {
            Producto producto = db.Producto.Find(id);
            byte[] byteImage = producto.img_prod;

            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }
        */
        public ActionResult Create()
        {
            ViewBag.categorias = new SelectList(db.Categoria, "idCategoria", "nom_cat");
            return View(new Producto());
        }
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }               
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categorias = new SelectList(db.Categoria, "idCategoria", "nom_cat", producto.idCategoria);
            return View(producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        public ActionResult Delete(FormCollection fcNotUsed, int id = 0)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}