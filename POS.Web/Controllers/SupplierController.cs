using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;

        public SupplierController(ApplicationDbContext context)
        {
            _service = new SupplierService(context);
        }

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
        [HttpPost]
        public IActionResult Save([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Add(request);
                return Redirect("Index");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var supplier = _service.View(id);
            return View(supplier);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var supplier = _service.View(id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierModel supplier)
        {
            if (ModelState.IsValid)
            {
                SupplierEntity supplierEntity = new SupplierEntity(supplier);
                supplierEntity.Id = supplier.Id;
                supplier = _service.Update(supplierEntity);
                return Redirect("Index");
            }
            return View("Edit", supplier);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Supplier");
        }
    }
}
