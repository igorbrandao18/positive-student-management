using PositiveStudentManagement.Constants;
using PositiveStudentManagement.Models;

namespace PositiveStudentManagement.Helpers
{
    public static class StudentHelper
    {
        public static string GenerateStudentId(int nextId)
        {
            return $"STU{nextId:D7}";
        }

        public static string GetEducationLevel(string grade)
        {
            return grade switch
            {
                StudentConstants.Grades.G1 or StudentConstants.Grades.G2 or StudentConstants.Grades.G3 => StudentConstants.EducationLevels.Infant,
                StudentConstants.Grades.FirstGrade or StudentConstants.Grades.SecondGrade or StudentConstants.Grades.ThirdGrade or 
                StudentConstants.Grades.FourthGrade or StudentConstants.Grades.FifthGrade => StudentConstants.EducationLevels.EarlyYears,
                StudentConstants.Grades.SixthGrade or StudentConstants.Grades.SeventhGrade or StudentConstants.Grades.EighthGrade or 
                StudentConstants.Grades.NinthGrade => StudentConstants.EducationLevels.LaterYears,
                _ => StudentConstants.EducationLevels.HighSchool
            };
        }

        public static bool ValidateAgeForGrade(int age, string grade)
        {
            if (!StudentConstants.AgeRanges.GradeAgeRanges.TryGetValue(grade, out var range))
                return false;

            return age >= range.Min && age <= range.Max;
        }

        public static int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public static List<string> GetAllGrades()
        {
            return new List<string>
            {
                StudentConstants.Grades.G1,
                StudentConstants.Grades.G2,
                StudentConstants.Grades.G3,
                StudentConstants.Grades.FirstGrade,
                StudentConstants.Grades.SecondGrade,
                StudentConstants.Grades.ThirdGrade,
                StudentConstants.Grades.FourthGrade,
                StudentConstants.Grades.FifthGrade,
                StudentConstants.Grades.SixthGrade,
                StudentConstants.Grades.SeventhGrade,
                StudentConstants.Grades.EighthGrade,
                StudentConstants.Grades.NinthGrade,
                StudentConstants.Grades.TenthGrade,
                StudentConstants.Grades.EleventhGrade,
                StudentConstants.Grades.TwelfthGrade
            };
        }

        public static List<string> GetAllAddressTypes()
        {
            return new List<string>
            {
                StudentConstants.AddressTypes.Billing,
                StudentConstants.AddressTypes.Residential,
                StudentConstants.AddressTypes.Correspondence
            };
        }
    }
}
