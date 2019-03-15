using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnidadPedagogicaSD.StaticInfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            return View();
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {


            return View();

        }

        public ActionResult misionVision()
        {
            return View();
        }

        public ActionResult Filosofia()
        {
            return View();
        }
        public ActionResult Valores()
        {
            return View();
        }
        public ActionResult Ubicacion()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(UnidadPedagogicaSDStaticInfo.DAL.usuariox r)
        {

            string cedula = r.cedula;
            string pass = r.pass;

            string pagina = "Login";
           
            var init = new Models.LoginModel();
            bool ok = init.InicioSesion(cedula, pass);
            try
            {
                if (ok)
                {
                    int rs = init.Rol(cedula, pass);
                    if (rs == 1)
                    {
                        System.Web.HttpContext.Current.Session["idRol"] = "1";
                        System.Web.HttpContext.Current.Session["Cedula"] = cedula;
                        pagina = "../mensajesProfes/inicioProfesor";

                    }
                    else if (rs == 2)
                    {
                        System.Web.HttpContext.Current.Session["Cedula"] = cedula;
                        System.Web.HttpContext.Current.Session["idRol"] = "2";
                        pagina = "../mensajesAdmin/InicioAdmin";
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Credenciales incorrectas');</script>";
                }
            }
            catch (Exception e)
            {
                TempData["msg"] = "<script>alert('Upps... Algo Salio Mal');</script>";
            }

            return View(pagina);

        }


        public ActionResult Historia()
        {
            return View();
        }
        public ActionResult docentesPrimaria()
        {
            return View();
        }
        public ActionResult docentesSecundaria()
        {
            return View();
        }

    }
}