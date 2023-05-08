using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class CategoryController : Controller
    {
        Product_Management_System_DBEntities Context = new Product_Management_System_DBEntities();

        // GET: Category
        public ActionResult Index()
        {
            var listofData = Context.Categories.ToList();
            return View(listofData);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var data = Context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            return View(data);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                Context.Categories.Add(model);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            return View(data);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit( Category model)
        {
            var data = Context.Categories.Where(x => x.CategoryID == model.CategoryID).FirstOrDefault();

            if (data != null)
            {
                data.CategoryName = model.CategoryName;
                Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            Context.Categories.Remove(data);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
