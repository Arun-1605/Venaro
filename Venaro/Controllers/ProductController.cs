using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;
using Venaro.Models.ViewModel;

namespace Venaro.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
			IEnumerable<Clothes> productList = _unitOfWork.Clothes.GetAll(includeProperties: "Category");

			return View(productList);
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Clothes = new(),
                Category = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                //create product
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(productVM);
            }
            else
            {
                productVM.Clothes = _unitOfWork.Clothes.GetFirstOrDefault(u => u.Id == id);
                return View(productVM);

                //update product
            }


        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Clothes.Image != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Clothes.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Clothes.Image = @"\images\products\" + fileName + extension;

                }
                if (obj.Clothes.Id == 0)
                {
                    _unitOfWork.Clothes.Add(obj.Clothes);
                }
                else
                {
                    _unitOfWork.Clothes.Update(obj.Clothes);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }


}
