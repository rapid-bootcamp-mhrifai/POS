using Microsoft.AspNetCore.Mvc;
using POS.Service;
using POS.Repository;

namespace POS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;
        public CategoryController(ApplicationDbContext context)
        {
            _service = new CategoryService(context);
        }

        public IActionResult Index()
        {
            var Data = _service.GetCategories();
            return View(Data);
        }
    }



}
