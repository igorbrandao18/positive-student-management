namespace PositiveStudentManagement.Constants
{
    public static class StudentConstants
    {
        public static class Grades
        {
            public const string G1 = "G1";
            public const string G2 = "G2";
            public const string G3 = "G3";
            public const string FirstGrade = "1st Grade";
            public const string SecondGrade = "2nd Grade";
            public const string ThirdGrade = "3rd Grade";
            public const string FourthGrade = "4th Grade";
            public const string FifthGrade = "5th Grade";
            public const string SixthGrade = "6th Grade";
            public const string SeventhGrade = "7th Grade";
            public const string EighthGrade = "8th Grade";
            public const string NinthGrade = "9th Grade";
            public const string TenthGrade = "10th Grade";
            public const string EleventhGrade = "11th Grade";
            public const string TwelfthGrade = "12th Grade";
        }

        public static class EducationLevels
        {
            public const string Infant = "Infant";
            public const string EarlyYears = "Early Years";
            public const string LaterYears = "Later Years";
            public const string HighSchool = "High School";
        }

        public static class AddressTypes
        {
            public const string Billing = "Billing";
            public const string Residential = "Residential";
            public const string Correspondence = "Correspondence";
        }

        public static class AgeRanges
        {
            public static readonly Dictionary<string, (int Min, int Max)> GradeAgeRanges = new()
            {
                { Grades.G1, (3, 5) },
                { Grades.G2, (3, 5) },
                { Grades.G3, (3, 5) },
                { Grades.FirstGrade, (6, 10) },
                { Grades.SecondGrade, (6, 10) },
                { Grades.ThirdGrade, (6, 10) },
                { Grades.FourthGrade, (6, 10) },
                { Grades.FifthGrade, (6, 10) },
                { Grades.SixthGrade, (11, 14) },
                { Grades.SeventhGrade, (11, 14) },
                { Grades.EighthGrade, (11, 14) },
                { Grades.NinthGrade, (11, 14) },
                { Grades.TenthGrade, (15, 17) },
                { Grades.EleventhGrade, (15, 17) },
                { Grades.TwelfthGrade, (15, 17) }
            };
        }

        public static class Validation
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
            public const int MaxStreetLength = 150;
            public const int MaxZipCodeLength = 10;
            public const int MaxNumberLength = 20;
            public const int MaxComplementLength = 100;
        }
    }
}
