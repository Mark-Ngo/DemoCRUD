using DemoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace DemoCRUD.Controllers
{
    public class CategoryController : Controller
    {
       
        // GET: Category
        public ActionResult Index()
        {
            var db = new DemoCrudDbContext();
            List<Category> categories = new List<Category>();
            categories = db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateData(Category category)
        {
            var db = new DemoCrudDbContext();
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var db = new DemoCrudDbContext();

            try
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                if(category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                     return RedirectToAction("E404", "Home");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }

    
}