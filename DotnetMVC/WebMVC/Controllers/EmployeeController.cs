using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    //int id, string employeeName, string email, string address, string phone, string position
    public class EmployeeController : Controller
    {
        private static List<EmployeeViewModel> _employeeViewModels = new List<EmployeeViewModel>()
        {
            new EmployeeViewModel(1, "Addyani Employee", "Addyani@gmail.com", "Jakarta", 821199889988, "BE"),
            new EmployeeViewModel(2, "Amirul Employee", "Amirul@gmail.com", "Bogor", 821199889987, "FE"),
            new EmployeeViewModel(3, "Fajar Employee", "Fajar@gmail.com", "Depok", 821199889986, "QA"),
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
        public IActionResult Save([Bind("Id, EmployeeName, Email, Address, Phone, Position")] EmployeeViewModel employee)
        {
            _employeeViewModels.Add(employee);
            return Redirect("List");
        }

        public IActionResult List()
        {
            return View(_employeeViewModels);
        }

        public IActionResult Edit(int? id)
        {
            EmployeeViewModel employee = _employeeViewModels.Find(x => x.Id.Equals(id));
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, EmployeeName, Email, Address, Phone, Position")] EmployeeViewModel employee)
        {
            EmployeeViewModel employeeOld = _employeeViewModels.Find(x => x.Id.Equals(id));
            _employeeViewModels.Remove(employeeOld);

            _employeeViewModels.Add(employee);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            EmployeeViewModel employee = (
                    from p in _employeeViewModels
                    where p.Id.Equals(id)
                    select p
                ).SingleOrDefault(new EmployeeViewModel());
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            EmployeeViewModel employee = _employeeViewModels.Find(x => x.Id.Equals(id));
            _employeeViewModels.Remove(employee);

            return Redirect("/Employee/List");
        }
    }
}
