using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        Product_Management_System_DBEntities Context = new Product_Management_System_DBEntities();

        public ActionResult Index()
        {
            var listofData = Context.ProductTables.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductTable model)
        {
            Context.ProductTables.Add(model);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = Context.ProductTables.Where(x => x.ProductID == Id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(ProductTable model)
        {
            var data = Context.ProductTables.Where(x => x.ProductID == model.ProductID).FirstOrDefault();

            if(data != null)
            {
                data.ProductName = model.ProductName;
                data.CategoryID = model.CategoryID;
                Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = Context.ProductTables.Where(x => x.ProductID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = Context.ProductTables.Where(x => x.ProductID == id).FirstOrDefault();
            Context.ProductTables.Remove(data);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}