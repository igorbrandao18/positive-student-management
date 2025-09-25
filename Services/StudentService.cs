using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Data;
using PositiveStudentManagement.Models;

namespace PositiveStudentManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            // Generate Registration Number
            var lastStudent = await _context.Students.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
            int nextId = (lastStudent?.Id ?? 0) + 1;
            student.StudentId = $"STU{nextId:D7}";

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidateAgeGradeAsync(Student student)
        {
            return await Task.FromResult(student.ValidateAgeGrade());
        }

        public async Task<int> GetTotalStudentsCountAsync()
        {
            return await _context.Students.CountAsync();
        }

        public async Task<IEnumerable<dynamic>> GetStudentsByGradeAsync()
        {
            return await _context.Students
                .GroupBy(s => s.Grade)
                .Select(g => new { Grade = g.Key, Total = g.Count() })
                .Cast<dynamic>()
                .ToListAsync();
        }

        public async Task<IEnumerable<dynamic>> GetStudentsByEducationLevelAsync()
        {
            return await _context.Students
                .GroupBy(s => s.EducationLevel)
                .Select(g => new { EducationLevel = g.Key, Total = g.Count() })
                .Cast<dynamic>()
                .ToListAsync();
        }

        public async Task<IEnumerable<dynamic>> GetStudentsBetween4And8YearsAsync()
        {
            return await _context.Students
                .Where(s => EF.Functions.DateDiffYear(s.DateOfBirth, DateTime.Now) >= 4 && 
                           EF.Functions.DateDiffYear(s.DateOfBirth, DateTime.Now) <= 8)
                .Select(s => new { FullName = s.FullName, Age = s.Age, EducationLevel = s.EducationLevel })
                .Cast<dynamic>()
                .ToListAsync();
        }

        public async Task<IEnumerable<dynamic>> GetSiblingsAsync()
        {
            return await _context.Students
                .GroupBy(s => new { s.FatherName, s.MotherName })
                .Where(g => g.Count() > 1)
                .Select(g => new { 
                    FatherName = g.Key.FatherName, 
                    MotherName = g.Key.MotherName, 
                    Count = g.Count(),
                    Students = g.Select(s => s.FullName).ToList()
                })
                .Cast<dynamic>()
                .ToListAsync();
        }
    }
}
