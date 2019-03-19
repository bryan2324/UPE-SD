using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using UnidadPedagogicaSDStaticInfo.DAL;

namespace UnidadPedagogicaSD.StaticInfo.Controllers
{
    public class usuarioxesController : Controller
    {
        private UPSDTCUXEntities db = new UPSDTCUXEntities();

        // GET: usuarioxes
        public ActionResult Index()
        {

            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "2")
            {
                return View(db.usuariox.ToList());

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // GET: usuarioxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuariox usuariox = db.usuariox.Find(id);
            if (usuariox == null)
            {
                return HttpNotFound();
            }

            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "2")
            {
                return View(usuariox);

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // GET: usuarioxes/Create
        public ActionResult Create()
        {
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "2")
            {

                return View();

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }

        }

        public ActionResult CreatebyToken()
        {
            int r = Convert.ToInt32(System.Web.HttpContext.Current.Session["tokenVerify"] as String);

            if (r == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Home/Index");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatebyToken([Bind(Include = "idUsuario,nombre,pass,cedula,idRol")] usuariox usuariox)
        {
            var Registro = new Models.LoginModel();

            int r = Convert.ToInt32(System.Web.HttpContext.Current.Session["tokenVerify"] as String);



            string pass = usuariox.pass;
            string cedula = usuariox.cedula;
            usuariox.idRol = 1;
            bool ok = false;
            bool ok2 = false;
            bool ok3 = Registro.registro(usuariox.cedula);
            Regex Val = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
            Val.IsMatch(cedula);
            if (Val.IsMatch(cedula) == true && cedula.Length == 9)  ///Verifica que hayan 9 numeros
            {
                ok = true;
            }

            if (pass.Length >= 4) //verfica que haya almenos 4 caracteres de clave
            {
                ok2 = true;
            }


            if (ModelState.IsValid && ok == true && ok2 == true && ok3 == false)
            {
                db.usuariox.Add(usuariox);
                db.SaveChanges();
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("../Home/Index");
            }
            else if (ModelState.IsValid && ok == false && ok2 == true)
            {
                TempData["msg"] = "<script>alert('Cedula debe Contener 9 Numeros');</script>";

                return View();
            }
            else if (ModelState.IsValid && ok == true && ok2 == false)
            {
                TempData["msg"] = "<script>alert('Clave debe contener 4 carateres o mas');</script>";
                return View();
            }
            else if (ModelState.IsValid && ok == true && ok2 == false && ok3 == false)
            {

                TempData["msg"] = "<script>alert('Clave debe contener 4 carateres o mas');</script>";
                return View();
            }
            else if (ModelState.IsValid && ok == true && ok2 == true && ok3 == true)
            {
                TempData["msg"] = "<script>alert('Ese numero de cedula ya existe en el sistema');</script>";
                return View();
            }
            else
            {
                TempData["msg"] = "<script>alert('Cedula debe Contener 9 Numeros');</script>";
                TempData["msg"] = "<script>alert('Clave debe contener 4 carateres o mas');</script>";

                return View();
            }
        
    

        }

        // POST: usuarioxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,nombre,pass,cedula,idRol")] usuariox usuariox)
        {
            var Registro = new Models.LoginModel();
            
            string pass = usuariox.pass;
            string cedula = usuariox.cedula;
            bool ok = false;
            bool ok2 = false;
            bool ok3= Registro.registro(usuariox.cedula);
            Regex Val = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
            Val.IsMatch(cedula);
            if (Val.IsMatch(cedula) == true && cedula.Length == 9) {
                ok = true;
            }

            if (pass.Length >= 4) {
                ok2 = true;
            }


            if (ModelState.IsValid && ok == true && ok2 == true && ok3 == false)
            {
                db.usuariox.Add(usuariox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid && ok == false && ok2 == true)
            {
                TempData["msg"] = "<script>alert('Cedula debe Contener 9 Numeros');</script>";

                return View();
            }
            else if (ModelState.IsValid && ok == true && ok2 == false)
            {
                TempData["msg"] = "<script>alert('Clave debe contener 4 carateres o mas');</script>";
                return View();
            }
            else if (ModelState.IsValid && ok == true && ok2 == false && ok3 == false)
            {

                TempData["msg"] = "<script>alert('Clave debe contener 4 carateres o mas');</script>";
                return View();
            }
            else if (ModelState.IsValid && ok == true && ok2 == true && ok3 == true)
            {
                TempData["msg"] = "<script>alert('Ese numero de cedula ya existe en el sistema');</script>";
                return View();
           }
            else
            {
                TempData["msg"] = "<script>alert('Cedula debe Contener 9 Numeros');</script>";
                TempData["msg"] = "<script>alert('Clave debe contener 4 carateres o mas');</script>";

                return View();
            }
            
            


            }
        

        // GET: usuarioxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuariox usuariox = db.usuariox.Find(id);
            if (usuariox == null)
            {
                return HttpNotFound();
            }
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "2")
            {
                return View(usuariox);

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // POST: usuarioxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,nombre,pass,cedula,idRol")] usuariox usuariox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "2")
            {
                return View(usuariox);

            }
            else
            {
                return View("../Home/Index");
            }
        }

        // GET: usuarioxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuariox usuariox = db.usuariox.Find(id);
            if (usuariox == null)
            {
                return HttpNotFound();
            }
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "2")
            {
                return View(usuariox);

            }
            else
            {
                return View("../Home/Index");
            }
        }

        // POST: usuarioxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuariox usuariox = db.usuariox.Find(id);
            db.usuariox.Remove(usuariox);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
