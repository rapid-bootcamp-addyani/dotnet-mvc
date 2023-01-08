using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    //int id, int employeeId, DateTime absentStartDate, DateTime absentEndDate, string location, string description
    public class AbsensiController : Controller
    {
        private static List<AbsensiViewModel> _absensiViewModels = new List<AbsensiViewModel>()
        {
            new AbsensiViewModel(1, 1, DateTime.Now, DateTime.Now.AddHours(2), "Bogor", "Complate Task 1"),
            new AbsensiViewModel(2, 3, DateTime.Now, DateTime.Now.AddHours(2).AddMinutes(30), "Bogor", "Complate Task 2"),
            new AbsensiViewModel(3, 5, DateTime.Now, DateTime.Now.AddHours(3).AddMinutes(15), "Bogor", "Complate Task 3"),
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
        public IActionResult Save([Bind("Id, EmployeeId, AbsentStartDate, AbsentEndDate, Location, Description")] AbsensiViewModel absensi)
        {
            _absensiViewModels.Add(absensi);
            return Redirect("List");
        }

        public IActionResult List()
        {
            return View(_absensiViewModels);
        }

        public IActionResult Edit(int? id)
        {
            AbsensiViewModel absensi = _absensiViewModels.Find(x => x.Id.Equals(id));
            return View(absensi);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, EmployeeId, AbsentStartDate, AbsentEndDate, Location, Description")] AbsensiViewModel absensi)
        {
            AbsensiViewModel absensiOld = _absensiViewModels.Find(x => x.Id.Equals(id));
            _absensiViewModels.Remove(absensiOld);

            _absensiViewModels.Add(absensi);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            AbsensiViewModel absensi = (
                    from p in _absensiViewModels
                    where p.Id.Equals(id)
                    select p
                ).SingleOrDefault(new AbsensiViewModel());
            return View(absensi);
        }

        public IActionResult Delete(int? id)
        {
            AbsensiViewModel absensi = _absensiViewModels.Find(x => x.Id.Equals(id));
            _absensiViewModels.Remove(absensi);

            return Redirect("/Absensi/List");
        }
    }
}
