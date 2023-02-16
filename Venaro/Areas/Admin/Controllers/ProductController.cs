using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Processing;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;
using Venaro.Models.ViewModel;

namespace Venaro.Area.Admin.Controllers
{
	[Area("Admin")]
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
            IEnumerable<Product> productList = _unitOfWork.Clothes.GetAll(includeProperties: "Category,Size,Colors");

            return View(productList);
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Products = new(),
                Category = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                } ),
                Colors = _unitOfWork.Color.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Color,
                    Value = i.Id.ToString()
                }),
                Size = _unitOfWork.Size.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Sizes,
                    Value = i.Id.ToString()
                }
                
               )

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
                productVM.Products = _unitOfWork.Clothes.GetFirstOrDefault(u => u.Id == id);
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


                    if (obj.Products.Image != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Products.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {

						using var image = Image.Load(file.OpenReadStream());
						image.Mutate(x => x.Resize(256, 256));


                        image.SaveAsJpeg(fileStreams);
                        //obj.Clothes.Image= image.Save(@"\images\products\" + fileName + extension);
                        //file.CopyTo(fileStreams);
                    }
                    obj.Products.Image = @"\images\products\" + fileName + extension;

                }
                if (obj.Products.Id == 0)
                {
                    _unitOfWork.Clothes.Add(obj.Products);
                }
                else
                {
                    _unitOfWork.Clothes.Update(obj.Products);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Clothes.GetAll(includeProperties: "Category,Size,Colors");
            return Json(new { data = productList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Clothes.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Clothes.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion


    }







}
