using PositiveStudentManagement.Constants;
using PositiveStudentManagement.Helpers;
using PositiveStudentManagement.Models;

namespace PositiveStudentManagement.Validators
{
    public static class StudentValidator
    {
        public static List<string> ValidateStudent(Student student)
        {
            var errors = new List<string>();

            // Full Name validation
            if (string.IsNullOrWhiteSpace(student.FullName))
                errors.Add("Full Name is required");
            else if (student.FullName.Length < StudentConstants.Validation.MinNameLength || 
                     student.FullName.Length > StudentConstants.Validation.MaxNameLength)
                errors.Add($"Full Name must be between {StudentConstants.Validation.MinNameLength} and {StudentConstants.Validation.MaxNameLength} characters");

            // Date of Birth validation
            if (student.DateOfBirth == default)
                errors.Add("Date of Birth is required");
            else if (student.DateOfBirth >= DateTime.Today)
                errors.Add("Date of Birth must be in the past");
            else if (student.DateOfBirth < DateTime.Today.AddYears(-25))
                errors.Add("Student must be younger than 25 years");

            // Grade validation
            if (string.IsNullOrWhiteSpace(student.Grade))
                errors.Add("Grade is required");
            else if (!StudentHelper.GetAllGrades().Contains(student.Grade))
                errors.Add("Invalid grade selected");

            // Address Type validation
            if (string.IsNullOrWhiteSpace(student.AddressType.ToString()))
                errors.Add("Address Type is required");

            // Street validation
            if (string.IsNullOrWhiteSpace(student.Street))
                errors.Add("Street is required");
            else if (student.Street.Length > StudentConstants.Validation.MaxStreetLength)
                errors.Add($"Street cannot exceed {StudentConstants.Validation.MaxStreetLength} characters");

            // ZIP Code validation
            if (string.IsNullOrWhiteSpace(student.ZipCode))
                errors.Add("ZIP Code is required");
            else if (student.ZipCode.Length > StudentConstants.Validation.MaxZipCodeLength)
                errors.Add($"ZIP Code cannot exceed {StudentConstants.Validation.MaxZipCodeLength} characters");

            // Number validation
            if (string.IsNullOrWhiteSpace(student.Number))
                errors.Add("Number is required");
            else if (student.Number.Length > StudentConstants.Validation.MaxNumberLength)
                errors.Add($"Number cannot exceed {StudentConstants.Validation.MaxNumberLength} characters");

            // Complement validation
            if (!string.IsNullOrWhiteSpace(student.Complement) && 
                student.Complement.Length > StudentConstants.Validation.MaxComplementLength)
                errors.Add($"Complement cannot exceed {StudentConstants.Validation.MaxComplementLength} characters");

            // Father's Name validation
            if (string.IsNullOrWhiteSpace(student.FatherName))
                errors.Add("Father's Name is required");
            else if (student.FatherName.Length < StudentConstants.Validation.MinNameLength || 
                     student.FatherName.Length > StudentConstants.Validation.MaxNameLength)
                errors.Add($"Father's Name must be between {StudentConstants.Validation.MinNameLength} and {StudentConstants.Validation.MaxNameLength} characters");

            // Mother's Name validation
            if (string.IsNullOrWhiteSpace(student.MotherName))
                errors.Add("Mother's Name is required");
            else if (student.MotherName.Length < StudentConstants.Validation.MinNameLength || 
                     student.MotherName.Length > StudentConstants.Validation.MaxNameLength)
                errors.Add($"Mother's Name must be between {StudentConstants.Validation.MinNameLength} and {StudentConstants.Validation.MaxNameLength} characters");

            // Age vs Grade validation
            if (!StudentHelper.ValidateAgeForGrade(student.Age, student.Grade))
                errors.Add("Student's age does not match the selected grade");

            return errors;
        }
    }
}
