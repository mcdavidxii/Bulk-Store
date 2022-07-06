using Bulk_Book.Data;
using Bulk_Book.Models;
using Microsoft.AspNetCore.Mvc;


namespace Bulk_Book.Controllers
{
    public class CategoryController : Controller
    {


        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db) 
        {
            _db = db;
        }// category controller
        public IActionResult Index()
        {
            //the operation will retrieve whatever that is in Db and convert it to a list

            //var objCategoryList = _db.categories.ToList();

            IEnumerable<Category> objCategoryList = _db.categories;

            return View(objCategoryList);
        }// IactionResult

        //get
        public IActionResult Create() 
        {
            return View();
        }//create



     

        //post
        [HttpPost]
        //to prevent cross site fogery
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("Custom Error","The display order can not exactly match the Name");
            }

            if (ModelState.IsValid) 
            {
                _db.categories.Add(obj);
                //query sent to the Database
                _db.SaveChanges();
                //notification
                TempData["success"] = "Category created successfully";
                return RedirectToAction("index");
            }

            return View(obj);
        }//create

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }//if id
            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDb = _db.categories.FirstOrDefault(u => u.ID == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }//if category

            return View(categoryFromDb);
        }//edit

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "The display order can not exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                //query sent to the Database
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("index");
            }

            return View(obj);
        }//edit


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }//if id
            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDb = _db.categories.FirstOrDefault(u => u.ID == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }//if category

            return View(categoryFromDb);
        }//delete

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.categories.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }//if

                _db.categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToAction("index");
            

            return View(obj);
        }//delete
    }// public class
}// namespace
