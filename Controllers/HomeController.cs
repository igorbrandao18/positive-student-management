using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Data;

namespace PositiveStudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalStudents = await _context.Students.CountAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
