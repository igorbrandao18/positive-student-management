namespace PositiveStudentManagement.Constants
{
    public static class StudentConstants
    {
        public static class Grades
        {
            public const string G1 = "G1";
            public const string G2 = "G2";
            public const string G3 = "G3";
            public const string FirstGrade = "1º ano";
            public const string SecondGrade = "2º ano";
            public const string ThirdGrade = "3º ano";
            public const string FourthGrade = "4º ano";
            public const string FifthGrade = "5º ano";
            public const string SixthGrade = "6º ano";
            public const string SeventhGrade = "7º ano";
            public const string EighthGrade = "8º ano";
            public const string NinthGrade = "9º ano";
            public const string TenthGrade = "1º ano ensino médio";
            public const string EleventhGrade = "2º ano ensino médio";
            public const string TwelfthGrade = "3º ano ensino médio";
        }

        public static class EducationLevels
        {
            public const string Infantil = "Infantil";
            public const string AnosIniciais = "Anos iniciais";
            public const string AnosFinais = "Anos finais";
            public const string EnsinoMedio = "Ensino Médio";
        }

        public static class AddressTypes
        {
            public const string Cobranca = "Cobrança";
            public const string Residencial = "Residencial";
            public const string Correspondencia = "Correspondência";
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
