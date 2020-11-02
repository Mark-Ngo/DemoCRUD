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


        [HttpPost]
        public ActionResult CreateCategory(Category data)
        {
            var db = new DemoCrudDbContext();
            try
            {
                db.Categories.Add(data);
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
                if (category != null)
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

        public ActionResult Update(int id)
        {
            var db = new DemoCrudDbContext();
            var product = db.Categories.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("E404", "Index");
            }
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category data)
        {
            var db = new DemoCrudDbContext();
            try
            {
                var product = db.Categories.FirstOrDefault(x => x.Id == data.Id);
                if (product != null)
                {

                    product.Name = data.Name;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("E404", "Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}