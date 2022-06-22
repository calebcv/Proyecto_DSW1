using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_DSW1.Models;

namespace Proyecto_DSW1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        BD_DSW1Entities db = new BD_DSW1Entities();

        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(Usuario oUsuario)
        {
            //bool registrado;
            //string mensaje;

            //if (oUsuario.clave_usu == oUsuario.clave_usu)
            //{

            //    oUsuario.clave_usu = ConvertirSha256(oUsuario.clave_usu);

            //}
            //else
            //{
            //    ViewData["Mensaje"] = "Las contraseñas no coinciden";
            //    return View();
            //}

            //using (SqlConnection cn = new SqlConnection(cadena))
            //{

            //    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
            //    cmd.Parameters.AddWithValue("usuario", oUsuario.nom_usu);
            //    cmd.Parameters.AddWithValue("clave", oUsuario.clave_usu);
            //    cmd.Parameters.Add("registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
            //    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cn.Open();

            //    cmd.ExecuteNonQuery();

            //    registrado = Convert.ToBoolean(cmd.Parameters["registrado"].Value);
            //    mensaje = cmd.Parameters["mensaje"].Value.ToString();


            //}

            //ViewData["Mensaje"] = mensaje;

            //if (registrado)
            //{
            //    return RedirectToAction("Login", "Acceso");
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            //oUsuario.clave_usu = ConvertirSha256(oUsuario.clave_usu);

            //using (SqlConnection cn = new SqlConnection(cadena))
            //{

            //    SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
            //    cmd.Parameters.AddWithValue("usuario", oUsuario.nom_usu);
            //    cmd.Parameters.AddWithValue("clave", oUsuario.clave_usu);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cn.Open();

            //    oUsuario.idUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            //}

            //if (oUsuario.idUsuario != 0)
            //{

            //    Session["usuario"] = oUsuario;
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ViewData["Mensaje"] = "usuario no encontrado";
            //    return View();
            //}

            return View();
        }



        //public static string ConvertirSha256(string texto)
        //{
        //    //using System.Text;
        //    //USAR LA REFERENCIA DE "System.Security.Cryptography"

        //    //StringBuilder Sb = new StringBuilder();
        //    //using (SHA256 hash = SHA256Managed.Create())
        //    //{
        //    //    Encoding enc = Encoding.UTF8;
        //    //    byte[] result = hash.ComputeHash(enc.GetBytes(texto));

        //    //    foreach (byte b in result)
        //    //        Sb.Append(b.ToString("x2"));
        //    //}

        //    //return Sb.ToString();

        //}
    }
}