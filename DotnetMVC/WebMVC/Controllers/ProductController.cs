using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private static List<ProductViewModel> _productViewModels = new List<ProductViewModel>()
        {
            new ProductViewModel(1, "Juz Mangga", "Minuman", 10000),
            new ProductViewModel(2, "Juz Alpukat", "Minuman", 10000),
            new ProductViewModel(3, "Mie Goreng Telor", "Makanan", 15000),
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, Name, Category, Price")] ProductViewModel product)
        {
            _productViewModels.Add(product);
            return Redirect("List");
        }

        public IActionResult List()
        {
            return View(_productViewModels);
        }

        public IActionResult Edit(int? id)
        {
            ProductViewModel product = _productViewModels.Find(x => x.Id.Equals(id));
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, Name, Category, Price")] ProductViewModel product)
        {
            ProductViewModel productOld = _productViewModels.Find(x => x.Id.Equals(id));
            _productViewModels.Remove(productOld);

            _productViewModels.Add(product);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            ProductViewModel product = (
                    from p in _productViewModels
                    where p.Id.Equals(id)
                    select p
                ).SingleOrDefault(new ProductViewModel());
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            ProductViewModel product = _productViewModels.Find(x => x.Id.Equals(id));
            _productViewModels.Remove(product);

            return Redirect("/Product/List");
        }
    }

}
