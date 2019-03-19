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
    public class mensajesProfesController : Controller
    {
        private UPSDTCUXEntities db = new UPSDTCUXEntities();

        // GET: mensajesProfes

        public ActionResult inicioProfesor()
        {
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "1")
            {
                return View();

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }


        public ActionResult Index()
        {
            var mensajex = db.mensajex.Include(m => m.usuariox);
            
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "1")
            {
                return View(mensajex.ToList());

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // GET: mensajesProfes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mensajex mensajex = db.mensajex.Find(id);
            if (mensajex == null)
            {
                return HttpNotFound();
            }
           
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "1")
            {
                return View(mensajex);

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // GET: mensajesProfes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.usuariox, "idUsuario", "nombre");
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "1")
            {
                return View();

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // POST: mensajesProfes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMensaje,cuerpo,fecha,idUsuario")] mensajex mensajex)
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo serverZone = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, serverZone);

            var backId = new Models.LoginModel();
            string ced = System.Web.HttpContext.Current.Session["Cedula"] as String;
            mensajex.idUsuario = backId.obtenerIdUsuario(ced);

            mensajex.fecha = currentDateTime;
            if (ModelState.IsValid)
            {
                db.mensajex.Add(mensajex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.usuariox, "idUsuario", "nombre", mensajex.idUsuario);
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "1")
            {
                return View(mensajex);

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // GET: mensajesProfes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mensajex mensajex = db.mensajex.Find(id);
            if (mensajex == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.usuariox, "idUsuario", "nombre", mensajex.idUsuario);
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "1")
            {
                return View(mensajex);

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // POST: mensajesProfes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMensaje,cuerpo,fecha,idUsuario")] mensajex mensajex)
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo serverZone = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, serverZone);

            mensajex.fecha = currentDateTime;

            if (ModelState.IsValid)
            {
                db.Entry(mensajex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.usuariox, "idUsuario", "nombre", mensajex.idUsuario);
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "1")
            {
                return View(mensajex);

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // GET: mensajesProfes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mensajex mensajex = db.mensajex.Find(id);
            if (mensajex == null)
            {
                return HttpNotFound();
            }
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "1")
            {
                return View(mensajex);

            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        // POST: mensajesProfes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mensajex mensajex = db.mensajex.Find(id);
            db.mensajex.Remove(mensajex);
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
