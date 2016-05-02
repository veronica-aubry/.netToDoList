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
        private IItemRepository itemRepo;

        public ItemsController(IItemRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.itemRepo = new EFItemRepository();
            }
            else
            {
                this.itemRepo = thisRepo;
            }
        }


        public ViewResult Index()
        {
            return View(itemRepo.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            itemRepo.Save(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            itemRepo.Edit(item);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            itemRepo.Remove(thisItem);
            return RedirectToAction("Index");
        }
    }
}



//public class ItemsController : Controller
//    {
//        private IItemRepository itemRepo;

//        public ItemsController(IItemRepository thisRepo = null)
//        {
//            if (thisRepo == null)
//            {
//                this.itemRepo = new EFItemRepository();
//            }
//            else
//            {
//                this.itemRepo = thisRepo;
//            }
//        }

//        //private ToDoListContext db = new ToDoListContext();
//        public IActionResult Index()
//        {
//            var itemList = itemRepo.Items.ToList();
//            //var itemList = db.itemcategories.Include(x => x.Item).Include(x => x.Category).ToList();
//            //var categoryList = db.Categories.Include(x => x.itemcategories).ToList();
//            //ViewBag.categories = categoryList;
//            return View(itemList);
//        }
//        public IActionResult Details(int id)
//        {
//            var thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
//            return View(thisItem);
//        }

//        [HttpPost]
//        public ActionResult Create(Item item)
//        {
//            itemRepo.Save(item);
//            return RedirectToAction("Index");
//        }
//        public ActionResult Edit(int id)
//        {
//            var thisItem = itemRepo.Items.FirstOrDefault(d => d.ItemId == id);
//            //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//            return View(thisItem);
//        }
//        [HttpPost]
//        public ActionResult Edit(Item item)
//        {
//            itemRepo.Edit(item);
//            return RedirectToAction("Index");
//        }
//        public ActionResult Delete(int id)
//        {
//            var thisItem = itemRepo.Items.FirstOrDefault(d => d.ItemId == id);
//            return View(thisItem);
//        }
//        [HttpPost, ActionName("Delete")]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            var thisItem = itemRepo.Items.FirstOrDefault(d => d.ItemId == id);
//            itemRepo.Remove(thisItem);
//            return RedirectToAction("Index");
//        }

//        //public void addCategory()
//        //{
//        //    ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//        //}
//    }
//}

//namespace WebApplication1.Controllers
//{
//    public class ItemsController : Controller
//    {
//        private ToDoListContext db = new ToDoListContext();
//        public IActionResult Index()
//        {
//            var itemList = db.itemcategories.Include(x => x.Item).Include(x => x.Category).ToList();
//            var categoryList = db.Categories.Include(x => x.itemcategories).ToList();
//            ViewBag.categories = categoryList;
//            return View(itemList);
//        }
//        public IActionResult Details(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
//            return View(thisItem);
//        }

//        [HttpPost]
//        public ActionResult Create(Item item)
//        {
//            db.Items.Add(item);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public ActionResult Edit(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(d => d.ItemId == id);
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//            return View(thisItem);
//        }
//        [HttpPost]
//        public ActionResult Edit(Item item)
//        {
//            db.Entry(item).State = EntityState.Modified;
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public ActionResult Delete(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(d => d.ItemId == id);
//            return View(thisItem);
//        }
//        [HttpPost, ActionName("Delete")]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(d => d.ItemId == id);
//            db.Items.Remove(thisItem);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public void addCategory()
//        {
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//        }
//    }
//}