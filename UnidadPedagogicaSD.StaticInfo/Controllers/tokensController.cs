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
    public class tokensController : Controller
    {
        private UPSDTCUXEntities db = new UPSDTCUXEntities();

        // GET: tokens
        public ActionResult Index()
        {
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (r == "2")
            {
                return View(db.tokens.ToList());

            }
            else
            {
                return View("../Home/Index");
            }

            
        }

        // GET: tokens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tokens tokens = db.tokens.Find(id);
            if (tokens == null)
            {
                return HttpNotFound();
            }
            return View(tokens);
        }

        // GET: tokens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tokens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: tokens/Edit/5
        public ActionResult Edit(int? id)
        {
            string r = System.Web.HttpContext.Current.Session["idRol"] as String;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tokens tokens = db.tokens.Find(id);
            if (tokens == null)
            {
                return HttpNotFound();
            }
            
            if (r == "2")
            {
                return View(tokens);

            }
            else
            {
                return View("../Home/Index");
            }

        }

        // POST: tokens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idToken,token")] tokens tokens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tokens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tokens);
        }

        // GET: tokens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tokens tokens = db.tokens.Find(id);
            if (tokens == null)
            {
                return HttpNotFound();
            }
            return View(tokens);
        }

        // POST: tokens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tokens tokens = db.tokens.Find(id);
            db.tokens.Remove(tokens);
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
