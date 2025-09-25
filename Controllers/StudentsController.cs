using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Data;
using PositiveStudentManagement.Models;

namespace PositiveStudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
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
                // Generate student ID automatically
                var lastStudent = await _context.Students.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
                var nextNumber = lastStudent?.Id + 1 ?? 1;
                student.StudentId = $"STU{nextNumber:D6}";

                // Calculate education level automatically
                student.CalculateEducationLevel();

                // Validate age vs grade
                if (!student.ValidateAgeGrade())
                {
                    ModelState.AddModelError("Grade", $"The student's age ({student.Age} years) does not match the selected grade.");
                    return View(student);
                }

                _context.Add(student);
                await _context.SaveChangesAsync();
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

            var student = await _context.Students.FindAsync(id);
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
                    // Calculate education level automatically
                    student.CalculateEducationLevel();

                    // Validate age vs grade
                    if (!student.ValidateAgeGrade())
                    {
                        ModelState.AddModelError("Grade", $"The student's age ({student.Age} years) does not match the selected grade.");
                        return View(student);
                    }

                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Reports
        public async Task<IActionResult> Reports()
        {
            var reports = new ReportsViewModel
            {
                TotalStudents = await _context.Students.CountAsync(),
                StudentsByGrade = await _context.Students
                    .GroupBy(s => s.Grade)
                    .Select(g => new { Grade = g.Key, Total = g.Count() })
                    .Cast<dynamic>()
                    .ToListAsync(),
                StudentsByEducationLevel = await _context.Students
                    .GroupBy(s => s.EducationLevel)
                    .Select(g => new { EducationLevel = g.Key, Total = g.Count() })
                    .Cast<dynamic>()
                    .ToListAsync(),
                StudentsBetween4And8Years = await _context.Students
                    .Where(s => EF.Functions.DateDiffYear(s.DateOfBirth, DateTime.Now) >= 4 && 
                               EF.Functions.DateDiffYear(s.DateOfBirth, DateTime.Now) <= 8)
                    .Select(s => new { FullName = s.FullName, Age = s.Age, EducationLevel = s.EducationLevel })
                    .Cast<dynamic>()
                    .ToListAsync(),
                Siblings = await _context.Students
                    .GroupBy(s => new { s.FatherName, s.MotherName })
                    .Where(g => g.Count() > 1)
                    .Select(g => new { 
                        FatherName = g.Key.FatherName, 
                        MotherName = g.Key.MotherName, 
                        Count = g.Count(),
                        Students = g.Select(s => s.FullName).ToList()
                    })
                    .Cast<dynamic>()
                    .ToListAsync()
            };

            return View(reports);
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }

    public class ReportsViewModel
    {
        public int TotalStudents { get; set; }
        public List<dynamic> StudentsByGrade { get; set; } = new();
        public List<dynamic> StudentsByEducationLevel { get; set; } = new();
        public List<dynamic> StudentsBetween4And8Years { get; set; } = new();
        public List<dynamic> Siblings { get; set; } = new();
    }
}
