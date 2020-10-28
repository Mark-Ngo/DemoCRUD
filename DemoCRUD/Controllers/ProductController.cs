using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoCRUD.Models;

namespace DemoCRUD.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new DemoCrudDbContext();
            var products = db.Products.ToList();

            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult GetProductJson(int id)
        {
            var db = new DemoCrudDbContext();
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return Json(new { status = true, data = product }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product data)
        {
            var db = new DemoCrudDbContext();
            try
            {
                db.Products.Add(data);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction("Index");
        }

        //Update

        public ActionResult Update(int id)
        {
            var db = new DemoCrudDbContext();
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("E404", "Home");
            }
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product data)
        {
            //
            //

            var db = new DemoCrudDbContext();
            try
            {
                var product = db.Products.FirstOrDefault(x => x.Id == data.Id);
                if (product != null)
                {
                    //update
                    product.Amount = data.Amount;
                    product.Name = data.Name;
                    product.Price = data.Price;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("E404", "Home");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            var db = new DemoCrudDbContext();
            try
            {
                var product = db.Products.FirstOrDefault(x => x.Id == id); // Lấy thằng đầu tiên nếu k có thì trả về null

                if (product != null)
                {
                    //update
                    db.Products.Remove(product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("E404", "Home");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}