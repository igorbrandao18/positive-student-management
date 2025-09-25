using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Data;
using PositiveStudentManagement.Services;
using PositiveStudentManagement.Scripts;

namespace PositiveStudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalStudents = await _studentService.GetTotalStudentsCountAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SeedStudents()
        {
            try
            {
                await PositiveStudentManagement.Scripts.SeedStudents.SeedDataAsync(HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>());
                TempData["SuccessMessage"] = "Students seeded successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error seeding students: {ex.Message}";
            }
            
            return RedirectToAction("Index");
        }
    }
}
