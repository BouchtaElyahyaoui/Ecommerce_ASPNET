using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECOMMERCE_Project_ASPNET;
using ECOMMERCE_Project_ASPNET.Models;

namespace ECOMMERCE_Project_ASPNET.Controllers
{
    public class HistoriquesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Historiques
        public ActionResult Index()
        {
            return View(db.Historiques.ToList());
        }

        // GET: Historiques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historique historique = db.Historiques.Find(id);
            if (historique == null)
            {
                return HttpNotFound();
            }
            return View(historique);
        }

        // GET: Historiques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Historiques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ProdId,Action")] Historique historique)
        {
            if (ModelState.IsValid)
            {
                db.Historiques.Add(historique);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historique);
        }

        // GET: Historiques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historique historique = db.Historiques.Find(id);
            if (historique == null)
            {
                return HttpNotFound();
            }
            return View(historique);
        }

        // POST: Historiques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ProdId,Action")] Historique historique)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historique).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historique);
        }

        // GET: Historiques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historique historique = db.Historiques.Find(id);
            if (historique == null)
            {
                return HttpNotFound();
            }
            return View(historique);
        }

        // POST: Historiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historique historique = db.Historiques.Find(id);
            db.Historiques.Remove(historique);
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
