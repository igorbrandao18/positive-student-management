-- Create database
CREATE DATABASE PositiveStudentManagement;
GO

USE PositiveStudentManagement;
GO

-- Create Students table
CREATE TABLE Students (
    Id int IDENTITY(1,1) PRIMARY KEY,
    StudentId nvarchar(50) NOT NULL,
    FullName nvarchar(100) NOT NULL,
    DateOfBirth date NOT NULL,
    AddressType int NOT NULL,
    Street nvarchar(200) NOT NULL,
    ZipCode nvarchar(9) NOT NULL,
    Number nvarchar(10) NOT NULL,
    Complement nvarchar(100) NULL,
    Grade nvarchar(20) NOT NULL,
    EducationLevel nvarchar(50) NULL,
    FatherName nvarchar(100) NOT NULL,
    MotherName nvarchar(100) NOT NULL
);
GO

-- Insert sample data
INSERT INTO Students (StudentId, FullName, DateOfBirth, AddressType, Street, ZipCode, Number, Complement, Grade, EducationLevel, FatherName, MotherName) VALUES
('STU000001', 'John Smith', '2010-05-15', 1, 'Main Street', '12345-678', '123', 'Apt 4B', '6th Grade', 'Middle School', 'Robert Smith', 'Mary Smith'),
('STU000002', 'Emily Johnson', '2012-03-22', 2, 'Oak Avenue', '23456-789', '456', NULL, '4th Grade', 'Elementary School', 'David Johnson', 'Sarah Johnson'),
('STU000003', 'Michael Brown', '2015-08-10', 1, 'Pine Road', '34567-890', '789', 'Unit 2', 'G2', 'Early Childhood', 'James Brown', 'Lisa Brown'),
('STU000004', 'Sarah Davis', '2009-12-05', 2, 'Cedar Lane', '45678-901', '321', NULL, '7th Grade', 'Middle School', 'William Davis', 'Jennifer Davis'),
('STU000005', 'David Wilson', '2011-07-18', 1, 'Maple Drive', '56789-012', '654', 'Suite 100', '5th Grade', 'Elementary School', 'Thomas Wilson', 'Patricia Wilson'),
('STU000006', 'Lisa Anderson', '2013-11-30', 2, 'Elm Street', '67890-123', '987', NULL, '3rd Grade', 'Elementary School', 'Christopher Anderson', 'Nancy Anderson'),
('STU000007', 'Robert Taylor', '2016-04-12', 1, 'Birch Boulevard', '78901-234', '147', 'Floor 3', 'G1', 'Early Childhood', 'Mark Taylor', 'Susan Taylor'),
('STU000008', 'Jennifer Martinez', '2008-09-25', 2, 'Spruce Circle', '89012-345', '258', NULL, '8th Grade', 'Middle School', 'Daniel Martinez', 'Karen Martinez'),
('STU000009', 'William Garcia', '2014-01-08', 1, 'Willow Way', '90123-456', '369', 'Building A', '2nd Grade', 'Elementary School', 'Paul Garcia', 'Betty Garcia'),
('STU000010', 'Patricia Rodriguez', '2017-06-14', 2, 'Ash Avenue', '01234-567', '741', NULL, 'G3', 'Early Childhood', 'Steven Rodriguez', 'Helen Rodriguez');
GO

-- Create indexes for better performance
CREATE INDEX IX_Students_StudentId ON Students(StudentId);
CREATE INDEX IX_Students_Grade ON Students(Grade);
CREATE INDEX IX_Students_EducationLevel ON Students(EducationLevel);
CREATE INDEX IX_Students_FatherName_MotherName ON Students(FatherName, MotherName);
GO
