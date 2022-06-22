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
    public class CarritoController : Controller
    {
        // GET: Carrito
        BD_DSW1Entities db = new BD_DSW1Entities();

        private int getIndex( int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for(int i = 0;i<compras.Count; i++)
            {
                if (compras[i].Producto.idProducto == id)
                    return i;
            }
            return -1;
        }

        public ActionResult AgregarCarrito(int id)
        {
            if(Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.Producto.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                    compras.Add(new CarritoItem(db.Producto.Find(id), 1));
                else
                    compras[IndexExistente].Cantidad ++;
                Session["carrito"] = compras;
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return View("AgregarCarrito");
        }

        public ActionResult FinalizarCompra()
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            if(compras != null && compras.Count > 0)
            {
                Pedido nuevaVenta = new Pedido();
                nuevaVenta.fech_pedido = DateTime.Now;
                nuevaVenta.Subtotal = compras.Sum(x => x.Producto.pre_prod * x.Cantidad);
                nuevaVenta.Iva = nuevaVenta.Subtotal * 0.18;
                nuevaVenta.Total = nuevaVenta.Subtotal + nuevaVenta.Iva;

                nuevaVenta.PedidoDetalle = (from Producto in compras
                                         select new PedidoDetalle
                                         {
                                             idProducto = Producto.Producto.idProducto ,
                                             Cantidad = Producto.Cantidad,
                                             Total = Producto.Cantidad * Producto.Producto.pre_prod
                                         }).ToList();
                db.Pedido.Add(nuevaVenta);
                db.SaveChanges();
                Session["carrito"] = new List<CarritoItem>();            
            }
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}