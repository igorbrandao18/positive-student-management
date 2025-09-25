-- Seed Data: 20 Students for Positive Student Management System
-- This script inserts 20 realistic students with varied data

USE [PositiveStudentManagement]
GO

-- Clear existing data (optional - uncomment if needed)
-- DELETE FROM Students
-- GO

-- Insert 20 students with realistic data
INSERT INTO Students (StudentId, FullName, DateOfBirth, AddressType, Street, ZipCode, Number, Complement, Grade, EducationLevel, FatherName, MotherName)
VALUES
-- Early Childhood Students (G1-G3)
('STU0000001', 'Ana Beatriz Silva', '2020-03-15', 1, 'Rua das Flores', '01234-567', '123', 'Apto 45', 'G1', 'Early Childhood', 'Carlos Silva', 'Maria Silva'),
('STU0000002', 'João Pedro Santos', '2019-07-22', 0, 'Av. Paulista', '01310-100', '1000', 'Sala 201', 'G2', 'Early Childhood', 'Roberto Santos', 'Patricia Santos'),
('STU0000003', 'Maria Eduarda Costa', '2018-11-08', 2, 'Rua Augusta', '01305-000', '456', NULL, 'G3', 'Early Childhood', 'Antonio Costa', 'Fernanda Costa'),

-- Elementary School Students (1st-5th Grade)
('STU0000004', 'Lucas Oliveira', '2017-05-12', 1, 'Rua Consolação', '01302-000', '789', 'Casa 2', '1st Grade', 'Elementary School', 'Marcos Oliveira', 'Sandra Oliveira'),
('STU0000005', 'Sophia Rodrigues', '2016-09-30', 0, 'Av. Faria Lima', '04538-132', '2500', 'Conjunto 301', '2nd Grade', 'Elementary School', 'Paulo Rodrigues', 'Cristina Rodrigues'),
('STU0000006', 'Gabriel Ferreira', '2015-12-03', 2, 'Rua Oscar Freire', '01426-001', '567', 'Apto 12', '3rd Grade', 'Elementary School', 'Ricardo Ferreira', 'Lucia Ferreira'),
('STU0000007', 'Isabella Almeida', '2014-08-18', 1, 'Rua Haddock Lobo', '01414-000', '890', 'Casa 5', '4th Grade', 'Elementary School', 'Fernando Almeida', 'Beatriz Almeida'),
('STU0000008', 'Rafael Martins', '2013-04-25', 0, 'Av. Rebouças', '05402-000', '1200', 'Sala 15', '5th Grade', 'Elementary School', 'Eduardo Martins', 'Camila Martins'),

-- Middle School Students (6th-9th Grade)
('STU0000009', 'Lara Pereira', '2012-10-14', 2, 'Rua Bela Cintra', '01415-000', '234', 'Apto 8', '6th Grade', 'Middle School', 'Gustavo Pereira', 'Renata Pereira'),
('STU0000010', 'Diego Souza', '2011-06-07', 1, 'Rua da Consolação', '01302-000', '345', 'Casa 3', '7th Grade', 'Middle School', 'Andre Souza', 'Monica Souza'),
('STU0000011', 'Beatriz Lima', '2010-01-20', 0, 'Av. Brigadeiro Luiz Antonio', '01317-000', '1800', 'Conjunto 205', '8th Grade', 'Middle School', 'Roberto Lima', 'Silvia Lima'),
('STU0000012', 'Thiago Barbosa', '2009-11-12', 2, 'Rua Augusta', '01305-000', '456', 'Apto 22', '9th Grade', 'Middle School', 'Carlos Barbosa', 'Ana Barbosa'),

-- High School Students (10th-12th Grade)
('STU0000013', 'Mariana Cardoso', '2008-07-05', 1, 'Rua Oscar Freire', '01426-001', '678', 'Casa 7', '10th Grade', 'High School', 'Jose Cardoso', 'Elena Cardoso'),
('STU0000014', 'Felipe Rocha', '2007-03-28', 0, 'Av. Paulista', '01310-100', '2000', 'Sala 45', '11th Grade', 'High School', 'Miguel Rocha', 'Claudia Rocha'),
('STU0000015', 'Camila Nunes', '2006-12-15', 2, 'Rua das Flores', '01234-567', '901', 'Apto 33', '12th Grade', 'High School', 'Pedro Nunes', 'Teresa Nunes'),

-- Additional Elementary Students
('STU0000016', 'Enzo Gomes', '2015-02-10', 1, 'Rua Haddock Lobo', '01414-000', '123', 'Casa 1', '3rd Grade', 'Elementary School', 'Fabio Gomes', 'Juliana Gomes'),
('STU0000017', 'Valentina Castro', '2014-09-18', 0, 'Av. Faria Lima', '04538-132', '3000', 'Conjunto 401', '4th Grade', 'Elementary School', 'Leonardo Castro', 'Vanessa Castro'),

-- Additional Middle School Students
('STU0000018', 'Nicolas Ribeiro', '2011-04-22', 2, 'Rua Consolação', '01302-000', '567', 'Apto 15', '7th Grade', 'Middle School', 'Alexandre Ribeiro', 'Carla Ribeiro'),
('STU0000019', 'Helena Dias', '2010-08-30', 1, 'Rua Bela Cintra', '01415-000', '234', 'Casa 4', '8th Grade', 'Middle School', 'Rodrigo Dias', 'Adriana Dias'),

-- Additional High School Student
('STU0000020', 'Arthur Mendes', '2007-11-25', 0, 'Av. Rebouças', '05402-000', '1500', 'Sala 25', '11th Grade', 'High School', 'Bruno Mendes', 'Leticia Mendes')

GO

-- Verify the data was inserted correctly
SELECT 
    StudentId,
    FullName,
    DATEDIFF(YEAR, DateOfBirth, GETDATE()) AS Age,
    Grade,
    EducationLevel,
    FatherName,
    MotherName
FROM Students
ORDER BY StudentId

GO

-- Show statistics
SELECT 
    EducationLevel,
    COUNT(*) AS StudentCount
FROM Students
GROUP BY EducationLevel
ORDER BY StudentCount DESC

GO

-- Show grade distribution
SELECT 
    Grade,
    COUNT(*) AS StudentCount
FROM Students
GROUP BY Grade
ORDER BY 
    CASE Grade
        WHEN 'G1' THEN 1
        WHEN 'G2' THEN 2
        WHEN 'G3' THEN 3
        WHEN '1st Grade' THEN 4
        WHEN '2nd Grade' THEN 5
        WHEN '3rd Grade' THEN 6
        WHEN '4th Grade' THEN 7
        WHEN '5th Grade' THEN 8
        WHEN '6th Grade' THEN 9
        WHEN '7th Grade' THEN 10
        WHEN '8th Grade' THEN 11
        WHEN '9th Grade' THEN 12
        WHEN '10th Grade' THEN 13
        WHEN '11th Grade' THEN 14
        WHEN '12th Grade' THEN 15
    END

GO
