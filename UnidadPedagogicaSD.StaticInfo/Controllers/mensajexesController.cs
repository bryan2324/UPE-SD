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
    public class mensajexesController : Controller
    {
        private UPSDTCUXEntities db = new UPSDTCUXEntities();

        // GET: mensajexes
        public ActionResult Index()
        {
            var mensajex = db.mensajex.Include(m => m.usuariox);
            return View(mensajex.ToList());
        }

        // GET: mensajexes/Details/5
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
            return View(mensajex);
        }

        // GET: mensajexes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.usuariox, "idUsuario", "nombre");
            return View();
        }

        // POST: mensajexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMensaje,cuerpo,fecha,idUsuario,visible")] mensajex mensajex)
        {
            if (ModelState.IsValid)
            {
                db.mensajex.Add(mensajex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.usuariox, "idUsuario", "nombre", mensajex.idUsuario);
            return View(mensajex);
        }

        // GET: mensajexes/Edit/5
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
            return View(mensajex);
        }

        // POST: mensajexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMensaje,cuerpo,fecha,idUsuario,visible")] mensajex mensajex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensajex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.usuariox, "idUsuario", "nombre", mensajex.idUsuario);
            return View(mensajex);
        }

        // GET: mensajexes/Delete/5
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
            return View(mensajex);
        }

        // POST: mensajexes/Delete/5
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
