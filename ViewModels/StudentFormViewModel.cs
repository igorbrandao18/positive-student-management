using PositiveStudentManagement.Models;

namespace PositiveStudentManagement.ViewModels
{
    public class StudentFormViewModel
    {
        public Student Student { get; set; } = new Student();
        public string FormTitle { get; set; } = string.Empty;
        public string FormSubtitle { get; set; } = string.Empty;
        public string FormAction { get; set; } = string.Empty;
        public string SubmitButtonText { get; set; } = string.Empty;
        public bool IsEdit { get; set; } = false;
    }
}
