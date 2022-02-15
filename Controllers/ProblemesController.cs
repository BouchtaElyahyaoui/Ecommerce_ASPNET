using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECOMMERCE_Project_ASPNET.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ECOMMERCE_Project_ASPNET.Controllers
{
    public class ProblemesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Problemes
        public ActionResult Index()
        {
            return View(db.Problemes.ToList());
        }

        // GET: Problemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probleme probleme = db.Problemes.Find(id);
            if (probleme == null)
            {
                return HttpNotFound();
            }
            return View(probleme);
        }

        // GET: Problemes/Create
        public ActionResult Create()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            string id = user.Id;
            ViewBag.Iden = id;
            return View();
        }

        // POST: Problemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProb,MessageProb,StatusProb,UserId")] Probleme probleme)
        {
            if (ModelState.IsValid)
            {
                probleme.StatusProb = false;
                db.Problemes.Add(probleme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(probleme);
        }

        // GET: Problemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probleme probleme = db.Problemes.Find(id);
            if (probleme == null)
            {
                return HttpNotFound();
            }
            return View(probleme);
        }

        // POST: Problemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProb,MessageProb,StatusProb,UserId")] Probleme probleme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(probleme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(probleme);
        }

        // GET: Problemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probleme probleme = db.Problemes.Find(id);
            if (probleme == null)
            {
                return HttpNotFound();
            }
            return View(probleme);
        }

        // POST: Problemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Probleme probleme = db.Problemes.Find(id);
            db.Problemes.Remove(probleme);
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
