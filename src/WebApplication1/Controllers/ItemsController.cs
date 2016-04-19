using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using WebApplication1.Models;
using Microsoft.Data.Entity;

namespace WebApplication1.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {
            var itemList = db.itemcategories.Include(x => x.Item).Include(x => x.Category).ToList();
            var categoryList = db.Categories.Include(x => x.itemcategories).ToList();
            ViewBag.categories = categoryList;
            return View(itemList);
        }
        public IActionResult Details(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var thisItem = db.Items.FirstOrDefault(d => d.ItemId == id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View(thisItem);
        }
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisItem = db.Items.FirstOrDefault(d => d.ItemId == id);
            return View(thisItem);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Items.FirstOrDefault(d => d.ItemId == id);
            db.Items.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void addCategory()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
        }
    }
}