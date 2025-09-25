using PositiveStudentManagement.Models;

namespace PositiveStudentManagement.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
        Task<bool> ValidateAgeGradeAsync(Student student);
        Task<int> GetTotalStudentsCountAsync();
        Task<IEnumerable<dynamic>> GetStudentsByGradeAsync();
        Task<IEnumerable<dynamic>> GetStudentsByEducationLevelAsync();
        Task<IEnumerable<dynamic>> GetStudentsBetween4And8YearsAsync();
        Task<IEnumerable<dynamic>> GetSiblingsAsync();
    }
}
