using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
                return View("../Home/Index");
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
                return View("../Home/Index");
            }
        }

        // GET: usuarioxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usuarioxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,nombre,pass,cedula,idRol")] usuariox usuariox)
        {
            if (ModelState.IsValid)
            {
                db.usuariox.Add(usuariox);
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
                return View("../Home/Index");
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
