using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    //int id, string nameUser, string admin, string detail, bool status, DateTime date
    public class LoanInventoryController : Controller
    {
        private static List<LoanInventoryViewModel> _loanInventoryViewModels = new List<LoanInventoryViewModel>()
        {
            new LoanInventoryViewModel(1, "Addyani", "Admin Rapidtech", "Pinjam Laptop Asus Seri X", true, DateTime.Now),
            new LoanInventoryViewModel(2, "Amirul" , "Admin Rapidtech", "Pinjam Laptop MSI Seri X", true, DateTime.Now),
            new LoanInventoryViewModel(3, "Fajar"  , "Admin Rapidtech", "Pinjam Laptop HP Seri X", true, DateTime.Now),
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
        public IActionResult Save([Bind("Id, NameUser, Detail, Admin, Status")] LoanInventoryViewModel loanInventory)
        {
            loanInventory.Date = DateTime.Now;
            _loanInventoryViewModels.Add(loanInventory);
            return Redirect("List");
        }

        public IActionResult List()
        {
            return View(_loanInventoryViewModels);
        }

        public IActionResult Edit(int? id)
        {
            LoanInventoryViewModel loanInventory = _loanInventoryViewModels.Find(x => x.Id.Equals(id));
            return View(loanInventory);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, NameUser, Detail, Admin, Status")] LoanInventoryViewModel loanInventory)
        {
            LoanInventoryViewModel loanInventoryOld = _loanInventoryViewModels.Find(x => x.Id.Equals(id));
            _loanInventoryViewModels.Remove(loanInventoryOld);

            loanInventory.Date = DateTime.Now;
            _loanInventoryViewModels.Add(loanInventory);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            LoanInventoryViewModel loanInventory = (
                    from p in _loanInventoryViewModels
                    where p.Id.Equals(id)
                    select p
                ).SingleOrDefault(new LoanInventoryViewModel());
            return View(loanInventory);
        }

        public IActionResult Delete(int? id)
        {
            LoanInventoryViewModel loanInventory = _loanInventoryViewModels.Find(x => x.Id.Equals(id));
            _loanInventoryViewModels.Remove(loanInventory);

            return Redirect("/LoanInventory/List");
        }
    }
}
