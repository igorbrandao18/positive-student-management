using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Data;
using PositiveStudentManagement.Services;

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
    }
}
