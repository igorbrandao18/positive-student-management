using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PositiveStudentManagement.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        public string StudentId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "The name must have a maximum of 100 characters")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Address Type")]
        public AddressType AddressType { get; set; }

        [Required]
        [Display(Name = "Street")]
        [StringLength(200, ErrorMessage = "The street must have a maximum of 200 characters")]
        public string Street { get; set; } = string.Empty;

        [Required]
        [Display(Name = "ZIP Code")]
        [StringLength(9, ErrorMessage = "ZIP code must have 8 digits")]
        [RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage = "ZIP code must be in format 00000-000")]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Number")]
        [StringLength(10, ErrorMessage = "The number must have a maximum of 10 characters")]
        public string Number { get; set; } = string.Empty;

        [Display(Name = "Complement")]
        [StringLength(100, ErrorMessage = "The complement must have a maximum of 100 characters")]
        public string? Complement { get; set; }

        [Required]
        [Display(Name = "Grade")]
        public string Grade { get; set; } = string.Empty;

        [Display(Name = "Education Level")]
        public string EducationLevel { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Father's Name")]
        [StringLength(100, ErrorMessage = "The father's name must have a maximum of 100 characters")]
        public string FatherName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Mother's Name")]
        [StringLength(100, ErrorMessage = "The mother's name must have a maximum of 100 characters")]
        public string MotherName { get; set; } = string.Empty;

        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public void CalculateEducationLevel()
        {
            EducationLevel = Grade switch
            {
                "G1" or "G2" or "G3" => "Early Childhood",
                "1st Grade" or "2nd Grade" or "3rd Grade" or "4th Grade" or "5th Grade" => "Elementary School",
                "6th Grade" or "7th Grade" or "8th Grade" or "9th Grade" => "Middle School",
                "10th Grade" or "11th Grade" or "12th Grade" => "High School",
                _ => "Not Defined"
            };
        }

        public bool ValidateAgeGrade()
        {
            return Grade switch
            {
                "G1" => Age == 3,
                "G2" => Age == 4,
                "G3" => Age == 5,
                "1st Grade" => Age == 6,
                "2nd Grade" => Age == 7,
                "3rd Grade" => Age == 8,
                "4th Grade" => Age == 9,
                "5th Grade" => Age == 10,
                "6th Grade" => Age == 11,
                "7th Grade" => Age == 12,
                "8th Grade" => Age == 13,
                "9th Grade" => Age == 14,
                "10th Grade" => Age == 15,
                "11th Grade" => Age == 16,
                "12th Grade" => Age == 17,
                _ => false
            };
        }
    }

    public enum AddressType
    {
        [Display(Name = "Billing")]
        Billing,
        [Display(Name = "Residential")]
        Residential,
        [Display(Name = "Correspondence")]
        Correspondence
    }
}
