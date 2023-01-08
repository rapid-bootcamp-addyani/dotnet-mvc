using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class InventoryController : Controller
    {
        private static List<InventoryViewModel> _inventoryViewModels = new List<InventoryViewModel>()
        {
            new InventoryViewModel(1, "Laptop Asus Seri X", "Ram 128 Gb - Memory 4 TB SSD", 10, 2, 8),
            new InventoryViewModel(2, "Laptop HP Seri X", "Ram 128 Gb - Memory 4 TB SSD", 10, 5, 5),
            new InventoryViewModel(3, "Laptop MSI Seri X", "Ram 128 Gb - Memory 4 TB SSD", 10, 7, 3),
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
        public IActionResult Save([Bind("Id, Name, Specification, Quantity, OnLoan, Ready")] InventoryViewModel inventory)
        {
            _inventoryViewModels.Add(inventory);
            return Redirect("List");
        }

        public IActionResult List()
        {
            return View(_inventoryViewModels);
        }

        public IActionResult Edit(int? id)
        {
            InventoryViewModel inventory = _inventoryViewModels.Find(x => x.Id.Equals(id));
            return View(inventory);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, Name, Specification, Quantity, OnLoan, Ready")] InventoryViewModel inventory)
        {
            InventoryViewModel inventoryOld = _inventoryViewModels.Find(x => x.Id.Equals(id));
            _inventoryViewModels.Remove(inventoryOld);

            _inventoryViewModels.Add(inventory);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            InventoryViewModel inventory = (
                    from p in _inventoryViewModels
                    where p.Id.Equals(id)
                    select p
                ).SingleOrDefault(new InventoryViewModel());
            return View(inventory);
        }

        public IActionResult Delete(int? id)
        {
            InventoryViewModel inventory = _inventoryViewModels.Find(x => x.Id.Equals(id));
            _inventoryViewModels.Remove(inventory);

            return Redirect("/Inventory/List");
        }
    }
}
