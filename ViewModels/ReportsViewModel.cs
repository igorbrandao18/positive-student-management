namespace PositiveStudentManagement.ViewModels
{
    public class ReportsViewModel
    {
        public int TotalStudents { get; set; }
        public IEnumerable<dynamic> StudentsByGrade { get; set; } = new List<dynamic>();
        public IEnumerable<dynamic> StudentsByEducationLevel { get; set; } = new List<dynamic>();
        public IEnumerable<dynamic> StudentsBetween4And8Years { get; set; } = new List<dynamic>();
        public IEnumerable<dynamic> Siblings { get; set; } = new List<dynamic>();
    }
}
