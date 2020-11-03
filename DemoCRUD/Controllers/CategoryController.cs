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

        public JsonResult GetCategoriesJson()
        {
            var db = new DemoCrudDbContext();
            var categories = db.Categories.Select(x => x.Name).ToList();
            return categories.Count > 0
                ? Json(new { status = true, data = categories }, JsonRequestBehavior.AllowGet)
                : Json(new { status = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string keyword)
        {
            var db = new DemoCrudDbContext();
            var categories = db.Categories.Where(x => x.Name.Contains(keyword)).ToList();

            return View("Index", categories);
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