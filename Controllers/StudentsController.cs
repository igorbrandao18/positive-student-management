using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Data;
using PositiveStudentManagement.Models;
using PositiveStudentManagement.Services;
using PositiveStudentManagement.ViewModels;

namespace PositiveStudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _studentService.GetAllStudentsAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,DateOfBirth,AddressType,Street,ZipCode,Number,Complement,Grade,FatherName,MotherName")] Student student)
        {
            if (ModelState.IsValid)
            {
                // Validate age vs grade
                if (!await _studentService.ValidateAgeGradeAsync(student))
                {
                    ModelState.AddModelError("Grade", $"The student's age ({student.Age} years) does not match the selected grade.");
                    return View(student);
                }

                await _studentService.CreateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,FullName,DateOfBirth,AddressType,Street,ZipCode,Number,Complement,Grade,FatherName,MotherName")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Validate age vs grade
                    if (!await _studentService.ValidateAgeGradeAsync(student))
                    {
                        ModelState.AddModelError("Grade", $"The student's age ({student.Age} years) does not match the selected grade.");
                        return View(student);
                    }

                    await _studentService.UpdateStudentAsync(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _studentService.GetStudentByIdAsync(student.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _studentService.DeleteStudentAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Reports
        public async Task<IActionResult> Reports()
        {
            var reports = new ReportsViewModel
            {
                TotalStudents = await _studentService.GetTotalStudentsCountAsync(),
                StudentsByGrade = await _studentService.GetStudentsByGradeAsync(),
                StudentsByEducationLevel = await _studentService.GetStudentsByEducationLevelAsync(),
                StudentsBetween4And8Years = await _studentService.GetStudentsBetween4And8YearsAsync(),
                Siblings = await _studentService.GetSiblingsAsync()
            };

            return View(reports);
        }

    }
}
