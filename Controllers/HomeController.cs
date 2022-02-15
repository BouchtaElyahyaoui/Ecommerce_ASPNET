using ECOMMERCE_Project_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECOMMERCE_Project_ASPNET.Controllers
{
    public class HomeController : BaseController
    {
        Model1 db = new Model1();

        public ActionResult ChangeLanguage(string lang)
        {
            new GestionLanguages().SetLanguage(lang);
            return Redirect(Request.UrlReferrer.ToString());
            /* obtient les informations sur l'URL de la précédente requête du client
            qui était liée a la requête actuelle */
        }


        public ActionResult Index(string searching)
        {
            
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.categorie = new SelectList(db.Categories, "IdCat", "NomCat");
            ViewBag.produits = db.Produits.Where(a => a.LibelleProd.StartsWith(searching) || searching == null).ToList();


            return View(db.Produits.Where(a => a.LibelleProd.StartsWith(searching) || searching == null).ToList());

        }
       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}