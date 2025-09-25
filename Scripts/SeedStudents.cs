using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Data;
using PositiveStudentManagement.Models;

namespace PositiveStudentManagement.Scripts
{
    public class SeedStudents
    {
        public static async Task SeedDataAsync(ApplicationDbContext context)
        {
            if (await context.Students.AnyAsync())
            {
                Console.WriteLine("Students already exist in the database.");
                return;
            }

            var students = new List<Student>
            {
                new Student
                {
                    StudentId = "STU0000001",
                    FullName = "Ana Beatriz Silva",
                    DateOfBirth = new DateTime(2020, 3, 15),
                    AddressType = AddressType.Residential,
                    Street = "Rua das Flores",
                    ZipCode = "01234-567",
                    Number = "123",
                    Complement = "Apto 45",
                    Grade = "G1",
                    FatherName = "Carlos Silva",
                    MotherName = "Maria Silva"
                },
                new Student
                {
                    StudentId = "STU0000002",
                    FullName = "João Pedro Santos",
                    DateOfBirth = new DateTime(2019, 7, 22),
                    AddressType = AddressType.Billing,
                    Street = "Av. Paulista",
                    ZipCode = "01310-100",
                    Number = "1000",
                    Complement = "Sala 201",
                    Grade = "G2",
                    FatherName = "Roberto Santos",
                    MotherName = "Patricia Santos"
                },
                new Student
                {
                    StudentId = "STU0000003",
                    FullName = "Maria Eduarda Costa",
                    DateOfBirth = new DateTime(2018, 11, 8),
                    AddressType = AddressType.Correspondence,
                    Street = "Rua Augusta",
                    ZipCode = "01305-000",
                    Number = "456",
                    Complement = null,
                    Grade = "G3",
                    FatherName = "Antonio Costa",
                    MotherName = "Fernanda Costa"
                },

                new Student
                {
                    StudentId = "STU0000004",
                    FullName = "Lucas Oliveira",
                    DateOfBirth = new DateTime(2017, 5, 12),
                    AddressType = AddressType.Residential,
                    Street = "Rua Consolação",
                    ZipCode = "01302-000",
                    Number = "789",
                    Complement = "Casa 2",
                    Grade = "1st Grade",
                    FatherName = "Marcos Oliveira",
                    MotherName = "Sandra Oliveira"
                },
                new Student
                {
                    StudentId = "STU0000005",
                    FullName = "Sophia Rodrigues",
                    DateOfBirth = new DateTime(2016, 9, 30),
                    AddressType = AddressType.Billing,
                    Street = "Av. Faria Lima",
                    ZipCode = "04538-132",
                    Number = "2500",
                    Complement = "Conjunto 301",
                    Grade = "2nd Grade",
                    FatherName = "Paulo Rodrigues",
                    MotherName = "Cristina Rodrigues"
                },
                new Student
                {
                    StudentId = "STU0000006",
                    FullName = "Gabriel Ferreira",
                    DateOfBirth = new DateTime(2015, 12, 3),
                    AddressType = AddressType.Correspondence,
                    Street = "Rua Oscar Freire",
                    ZipCode = "01426-001",
                    Number = "567",
                    Complement = "Apto 12",
                    Grade = "3rd Grade",
                    FatherName = "Ricardo Ferreira",
                    MotherName = "Lucia Ferreira"
                },
                new Student
                {
                    StudentId = "STU0000007",
                    FullName = "Isabella Almeida",
                    DateOfBirth = new DateTime(2014, 8, 18),
                    AddressType = AddressType.Residential,
                    Street = "Rua Haddock Lobo",
                    ZipCode = "01414-000",
                    Number = "890",
                    Complement = "Casa 5",
                    Grade = "4th Grade",
                    FatherName = "Fernando Almeida",
                    MotherName = "Beatriz Almeida"
                },
                new Student
                {
                    StudentId = "STU0000008",
                    FullName = "Rafael Martins",
                    DateOfBirth = new DateTime(2013, 4, 25),
                    AddressType = AddressType.Billing,
                    Street = "Av. Rebouças",
                    ZipCode = "05402-000",
                    Number = "1200",
                    Complement = "Sala 15",
                    Grade = "5th Grade",
                    FatherName = "Eduardo Martins",
                    MotherName = "Camila Martins"
                },

                new Student
                {
                    StudentId = "STU0000009",
                    FullName = "Lara Pereira",
                    DateOfBirth = new DateTime(2012, 10, 14),
                    AddressType = AddressType.Correspondence,
                    Street = "Rua Bela Cintra",
                    ZipCode = "01415-000",
                    Number = "234",
                    Complement = "Apto 8",
                    Grade = "6th Grade",
                    FatherName = "Gustavo Pereira",
                    MotherName = "Renata Pereira"
                },
                new Student
                {
                    StudentId = "STU0000010",
                    FullName = "Diego Souza",
                    DateOfBirth = new DateTime(2011, 6, 7),
                    AddressType = AddressType.Residential,
                    Street = "Rua da Consolação",
                    ZipCode = "01302-000",
                    Number = "345",
                    Complement = "Casa 3",
                    Grade = "7th Grade",
                    FatherName = "Andre Souza",
                    MotherName = "Monica Souza"
                },
                new Student
                {
                    StudentId = "STU0000011",
                    FullName = "Beatriz Lima",
                    DateOfBirth = new DateTime(2010, 1, 20),
                    AddressType = AddressType.Billing,
                    Street = "Av. Brigadeiro Luiz Antonio",
                    ZipCode = "01317-000",
                    Number = "1800",
                    Complement = "Conjunto 205",
                    Grade = "8th Grade",
                    FatherName = "Roberto Lima",
                    MotherName = "Silvia Lima"
                },
                new Student
                {
                    StudentId = "STU0000012",
                    FullName = "Thiago Barbosa",
                    DateOfBirth = new DateTime(2009, 11, 12),
                    AddressType = AddressType.Correspondence,
                    Street = "Rua Augusta",
                    ZipCode = "01305-000",
                    Number = "456",
                    Complement = "Apto 22",
                    Grade = "9th Grade",
                    FatherName = "Carlos Barbosa",
                    MotherName = "Ana Barbosa"
                },

                new Student
                {
                    StudentId = "STU0000013",
                    FullName = "Mariana Cardoso",
                    DateOfBirth = new DateTime(2008, 7, 5),
                    AddressType = AddressType.Residential,
                    Street = "Rua Oscar Freire",
                    ZipCode = "01426-001",
                    Number = "678",
                    Complement = "Casa 7",
                    Grade = "10th Grade",
                    FatherName = "Jose Cardoso",
                    MotherName = "Elena Cardoso"
                },
                new Student
                {
                    StudentId = "STU0000014",
                    FullName = "Felipe Rocha",
                    DateOfBirth = new DateTime(2007, 3, 28),
                    AddressType = AddressType.Billing,
                    Street = "Av. Paulista",
                    ZipCode = "01310-100",
                    Number = "2000",
                    Complement = "Sala 45",
                    Grade = "11th Grade",
                    FatherName = "Miguel Rocha",
                    MotherName = "Claudia Rocha"
                },
                new Student
                {
                    StudentId = "STU0000015",
                    FullName = "Camila Nunes",
                    DateOfBirth = new DateTime(2006, 12, 15),
                    AddressType = AddressType.Correspondence,
                    Street = "Rua das Flores",
                    ZipCode = "01234-567",
                    Number = "901",
                    Complement = "Apto 33",
                    Grade = "12th Grade",
                    FatherName = "Pedro Nunes",
                    MotherName = "Teresa Nunes"
                },

                new Student
                {
                    StudentId = "STU0000016",
                    FullName = "Enzo Gomes",
                    DateOfBirth = new DateTime(2015, 2, 10),
                    AddressType = AddressType.Residential,
                    Street = "Rua Haddock Lobo",
                    ZipCode = "01414-000",
                    Number = "123",
                    Complement = "Casa 1",
                    Grade = "3rd Grade",
                    FatherName = "Fabio Gomes",
                    MotherName = "Juliana Gomes"
                },
                new Student
                {
                    StudentId = "STU0000017",
                    FullName = "Valentina Castro",
                    DateOfBirth = new DateTime(2014, 9, 18),
                    AddressType = AddressType.Billing,
                    Street = "Av. Faria Lima",
                    ZipCode = "04538-132",
                    Number = "3000",
                    Complement = "Conjunto 401",
                    Grade = "4th Grade",
                    FatherName = "Leonardo Castro",
                    MotherName = "Vanessa Castro"
                },

                new Student
                {
                    StudentId = "STU0000018",
                    FullName = "Nicolas Ribeiro",
                    DateOfBirth = new DateTime(2011, 4, 22),
                    AddressType = AddressType.Correspondence,
                    Street = "Rua Consolação",
                    ZipCode = "01302-000",
                    Number = "567",
                    Complement = "Apto 15",
                    Grade = "7th Grade",
                    FatherName = "Alexandre Ribeiro",
                    MotherName = "Carla Ribeiro"
                },
                new Student
                {
                    StudentId = "STU0000019",
                    FullName = "Helena Dias",
                    DateOfBirth = new DateTime(2010, 8, 30),
                    AddressType = AddressType.Residential,
                    Street = "Rua Bela Cintra",
                    ZipCode = "01415-000",
                    Number = "234",
                    Complement = "Casa 4",
                    Grade = "8th Grade",
                    FatherName = "Rodrigo Dias",
                    MotherName = "Adriana Dias"
                },

                new Student
                {
                    StudentId = "STU0000020",
                    FullName = "Arthur Mendes",
                    DateOfBirth = new DateTime(2007, 11, 25),
                    AddressType = AddressType.Billing,
                    Street = "Av. Rebouças",
                    ZipCode = "05402-000",
                    Number = "1500",
                    Complement = "Sala 25",
                    Grade = "11th Grade",
                    FatherName = "Bruno Mendes",
                    MotherName = "Leticia Mendes"
                }
            };

            foreach (var student in students)
            {
                student.CalculateEducationLevel();
            }

            await context.Students.AddRangeAsync(students);
            await context.SaveChangesAsync();

            Console.WriteLine($"Successfully seeded {students.Count} students to the database.");
        }
    }
}
