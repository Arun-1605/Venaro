using Microsoft.AspNetCore.Mvc;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;

namespace Venaro.Areas.Admin.Controllers
{

          [Area("Admin")]
        public class ColorController : Controller
        {
            private readonly IUnitOfWork _unitOfWork;

            public ColorController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public IActionResult Index()
            {
                IEnumerable<Colors> objColorList = _unitOfWork.Color.GetAll();
                return View(objColorList);
            }

            //GET
            public IActionResult Create()
            {
                return View();
            }

            //POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Colors obj)
            {
                //if (obj.Name == obj.DisplayOrder.ToString())
                //{
                //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
                //}
                if (ModelState.IsValid)
                {
                    _unitOfWork.Color.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Color created successfully";
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
                //var ColorFromDb = _db.Categories.Find(id);
                var ColorFromDbFirst = _unitOfWork.Color.GetFirstOrDefault(u => u.Id == id);
                //var ColorFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

                if (ColorFromDbFirst == null)
                {
                    return NotFound();
                }

                return View(ColorFromDbFirst);
            }

            //POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(Colors obj)
            {
                //if (obj.Name == obj.DisplayOrder.ToString())
                //{
                //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
                //}
                if (ModelState.IsValid)
                {
                    _unitOfWork.Color.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Color updated successfully";
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
                //var ColorFromDb = _db.Categories.Find(id);
                var ColorFromDbFirst = _unitOfWork.Color.GetFirstOrDefault(u => u.Id == id);
                //var ColorFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

                if (ColorFromDbFirst == null)
                {
                    return NotFound();
                }

                return View(ColorFromDbFirst);
            }

            //POST
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeletePOST(int? id)
            {
                var obj = _unitOfWork.Color.GetFirstOrDefault(u => u.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }

                _unitOfWork.Color.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Color deleted successfully";
                return RedirectToAction("Index");

            }
        }

    }

