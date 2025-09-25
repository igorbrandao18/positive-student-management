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
                "G1" or "G2" or "G3" => "Infantil",
                "1º ano" or "2º ano" or "3º ano" or "4º ano" or "5º ano" => "Anos iniciais",
                "6º ano" or "7º ano" or "8º ano" or "9º ano" => "Anos finais",
                "1º ano ensino médio" or "2º ano ensino médio" or "3º ano ensino médio" => "Ensino Médio",
                _ => "Não definido"
            };
        }

        public bool ValidateAgeGrade()
        {
            return Grade switch
            {
                "G1" => Age == 3,
                "G2" => Age == 4,
                "G3" => Age == 5,
                "1º ano" => Age == 6,
                "2º ano" => Age == 7,
                "3º ano" => Age == 8,
                "4º ano" => Age == 9,
                "5º ano" => Age == 10,
                "6º ano" => Age == 11,
                "7º ano" => Age == 12,
                "8º ano" => Age == 13,
                "9º ano" => Age == 14,
                "1º ano ensino médio" => Age == 15,
                "2º ano ensino médio" => Age == 16,
                "3º ano ensino médio" => Age == 17,
                _ => false
            };
        }
    }

    public enum AddressType
    {
        [Display(Name = "Cobrança")]
        Billing,
        [Display(Name = "Residencial")]
        Residential,
        [Display(Name = "Correspondência")]
        Correspondence
    }
}
