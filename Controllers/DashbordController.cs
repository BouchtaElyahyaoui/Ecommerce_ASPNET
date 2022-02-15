using ECOMMERCE_Project_ASPNET.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ECOMMERCE_Project_ASPNET.Controllers
{
    public class DashbordController : Controller
    {
        Model1 db = new Model1();
        
        // GET: Dashbord
        public ActionResult Index()
        {
            ViewBag.CountProp = db.AspNetUsers.Where(a => a.Role == "Proprietaire").Count();
            List<AspNetUser> L = db.AspNetUsers.Where(a => a.Role == "Proprietaire").ToList();
            ViewBag.CountProd = db.Produits.Count();
            ViewBag.Products = db.Produits.ToList();
            ViewBag.Histories = db.Histories.ToList();
            ViewBag.Problems = db.Problemes.ToList();
            ViewBag.Categories = db.Categories.ToList();
            
            ViewBag.Users = L.Where(a => a.EtatUser == 0 || a.EtatUser ==2).ToList();
            ViewBag.BlackLists = db.AspNetUsers.Where(a => a.EtatUser == 1).ToList();
            ViewBag.BlackListCount = db.AspNetUsers.Where(a => a.EtatUser == 1).Count();
            ViewBag.FavoriteCount = db.AspNetUsers.Where(a => a.EtatUser == 2).Count();
            ViewBag.Favorites = db.AspNetUsers.Where(a => a.EtatUser == 2).ToList();
            return View(db.AspNetUsers.ToList());
        }


        public ActionResult BlackList(string id)
        {
            var result = db.AspNetUsers.First(x => x.Id == id);
            result.EtatUser = 1;
            db.SaveChanges();
            /*RedirectToAction("Index","Dashbord");*/
            /*return View(result);*/
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Favorite(string id)
        {
            var result = db.AspNetUsers.First(x => x.Id == id);
            result.EtatUser = 2;
            db.SaveChanges();
            /*RedirectToAction("Index", "Dashbord");*/
            /*return View(result);*/
            return Redirect(Request.UrlReferrer.ToString());
        }
       

        public ActionResult UnBlackList(string id)
        {
            var result = db.AspNetUsers.First(x => x.Id == id);
            result.EtatUser = 0;
            db.SaveChanges();
            /*RedirectToAction("Index", "Dashbord");*/
            /* return View(result);*/
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult UnFavorite(string id)
        {
            var result = db.AspNetUsers.First(x => x.Id == id);
            result.EtatUser = 0;
            db.SaveChanges();
            /* RedirectToAction("Index", "Dashbord");*/
            /*return View(result);*/
            return Redirect(Request.UrlReferrer.ToString());
        }
        
        public ActionResult ProbSolved(int id)
        {
            var result = db.Problemes.First(x => x.IdProb == id);
            db.Problemes.Remove(result);
            db.SaveChanges();
            /* RedirectToAction("Index", "Dashbord");*/
            return Redirect(Request.UrlReferrer.ToString());
        }
         public ActionResult Delete(int id)
        {
            var result = db.Produits.First(x => x.IdProd == id);
            db.Produits.Remove(result);
            db.SaveChanges();
            RedirectToAction("Index", "Dashbord");
            return Redirect(Request.UrlReferrer.ToString());
        }


        
    }
}