using Microsoft.AspNetCore.Mvc;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;

namespace Venaro.Areas.Admin.Controllers
{

          [Area("Admin")]
        public class SizeController : Controller
        {
            private readonly IUnitOfWork _unitOfWork;

            public SizeController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public IActionResult Index()
            {
                IEnumerable<Size> objCategoryList = _unitOfWork.Size.GetAll();
                return View(objCategoryList);
            }

            //GET
            public IActionResult Create()
            {
                return View();
            }

            //POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Size obj)
            {
                //if (obj.Name == obj.DisplayOrder.ToString())
                //{
                //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
                //}
                if (ModelState.IsValid)
                {
                    _unitOfWork.Size.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction("Index");
                }
                return View(obj);
            }

            //GET
            public IActionResult Edit(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                //var categoryFromDb = _db.Categories.Find(id);
                var categoryFromDbFirst = _unitOfWork.Size.GetFirstOrDefault(u => u.Id == id);
                //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

                if (categoryFromDbFirst == null)
                {
                    return NotFound();
                }

                return View(categoryFromDbFirst);
            }

            //POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(Size obj)
            {
                //if (obj.Name == obj.DisplayOrder.ToString())
                //{
                //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
                //}
                if (ModelState.IsValid)
                {
                    _unitOfWork.Size.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Category updated successfully";
                    return RedirectToAction("Index");
                }
                return View(obj);
            }

            public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                //var categoryFromDb = _db.Categories.Find(id);
                var categoryFromDbFirst = _unitOfWork.Size.GetFirstOrDefault(u => u.Id == id);
                //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

                if (categoryFromDbFirst == null)
                {
                    return NotFound();
                }

                return View(categoryFromDbFirst);
            }

            //POST
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeletePOST(int? id)
            {
                var obj = _unitOfWork.Size.GetFirstOrDefault(u => u.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }

                _unitOfWork.Size.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");

            }
        }

    }

