using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;
        public EmployeeController(ApplicationDbContext context)
        {
            _service = new EmployeeService(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Data = _service.Get();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        public IActionResult Save(
            [Bind("LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath")] EmployeeModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new EmployeesEntity(request));
                return Redirect("Index");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var customer = _service.View(id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var customer = _service.View(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath")] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                _service.Update(employee);
                return Redirect("Index");
            }
            return View("Edit", employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Employee");
        }
    }
}