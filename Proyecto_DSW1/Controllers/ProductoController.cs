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

namespace Proyecto_DSW1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        BD_DSW1Entities db = new BD_DSW1Entities();
        public ActionResult Index()
        {
            return View(db.Producto.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.categorias = new SelectList(db.Categoria, "idCategoria", "nom_cat");
            return View();
        }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            HttpPostedFileBase fileBase = Request.Files[0];
            if (fileBase.ContentLength == 0)
            {
                ModelState.AddModelError("fotoproducto", "Es necesario seleccionar Imagen");
                return View(producto);
            }
            else
            {
                if (fileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage image = new WebImage(fileBase.InputStream);
                    producto.img_prod = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("fotoproducto", "No es formato adecuado");
                    return View(producto);
                }
            }               
            db.Producto.Add(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            HttpPostedFileBase fileBase = Request.Files[0];
            WebImage image = new WebImage(fileBase.InputStream);
            producto.img_prod = image.GetBytes();
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