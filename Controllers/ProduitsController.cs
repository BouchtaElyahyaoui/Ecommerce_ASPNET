using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECOMMERCE_Project_ASPNET.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ECOMMERCE_Project_ASPNET.Controllers
{
    public class ProduitsController : BaseController
    {
        private Model1 db = new Model1();
        /*private static int HistoryId = 1;*/



        // GET: Produits
        public ActionResult Index()
        {
            
            return View(db.Produits.ToList());
        }

      
        public ActionResult Index2()
        {
            string username = User.Identity.Name;
            return View(db.Produits.Where(a=>a.AspNetUser.UserName == username ).ToList());
        }

        



        // GET: Produits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: Produits/Create
        public ActionResult Create()
        {
            var categories = db.Categories.ToList();

            SelectList categoryList = new SelectList(categories, "IdCat", "NomCat");
            ViewBag.categoryList = categoryList;
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            string id = user.Id;
            ViewBag.Iden = id;
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProd,LibelleProd,DescriptionProd,PrixProd,ImageProd,ImageFile,UserId,CategorieId")] Produit produit)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            History history = new History();
            /*history.Id = HistoryId;*/
            history.UserName = user.UserName;
            history.ProductName = produit.LibelleProd;
            history.Action = "Created";
            string fileName = Path.GetFileNameWithoutExtension(produit.ImageFile.FileName);
            string extension = Path.GetExtension(produit.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            produit.ImageProd = "~/Content/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
           produit.ImageFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                db.Produits.Add(produit);
                db.Histories.Add(history);
                db.SaveChanges();
                return RedirectToAction("Index2","Produits");
            }
            return View(produit);
           
        }

        // GET: Produits/Edit/5
        public ActionResult Edit(int? id)
        {

            var categories = db.Categories.ToList();
           
            SelectList categoryList = new SelectList(categories, "IdCat", "NomCat");
            ViewBag.categoryList = categoryList;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProd,LibelleProd,DescriptionProd,PrixProd,ImageProd,ImageFile,UserId,CategorieId")] Produit produit)
        {
            var categories = db.Categories.ToList();
            SelectList categoryList = new SelectList(categories, "IdCat", "NomCat");
            ViewBag.categoryList = categoryList;
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            History history = new History();
            /*history.Id = HistoryId;*/
            history.UserName = user.UserName;
            history.ProductName = produit.LibelleProd;
            history.Action = "Created";
            string fileName = Path.GetFileNameWithoutExtension(produit.ImageFile.FileName);
            string extension = Path.GetExtension(produit.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            produit.ImageProd = "~/Content/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
            produit.ImageFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                
                db.Entry(produit).State = EntityState.Modified;
                db.Histories.Add(history);
                db.SaveChanges();
                return RedirectToAction("Index2", "Produits");
            }
            return View(produit);
        }

        // GET: Produits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produit produit = db.Produits.Find(id);
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            History history = new History();
            /*history.Id = HistoryId;*/
            history.UserName = user.UserName;
            history.ProductName = produit.LibelleProd;
            history.Action = "Deleted";
            if (ModelState.IsValid)
            {
                db.Histories.Add(history);
                db.Produits.Remove(produit);
                db.SaveChanges();
                return RedirectToAction("Index2", "Produits");
            }
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
