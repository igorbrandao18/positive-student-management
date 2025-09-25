-- ========================================
-- POSITIVE STUDENT MANAGEMENT SYSTEM
-- Required SQL Queries - Challenge Implementation
-- ========================================

USE PositiveStudentManagement;
GO

-- ========================================
-- 1. TOTAL STUDENTS REGISTERED
-- ========================================
SELECT COUNT(*) AS TotalStudents 
FROM Students;
GO

-- ========================================
-- 2. TOTAL STUDENTS BY GRADE
-- ========================================
SELECT Grade, COUNT(*) AS Total 
FROM Students 
GROUP BY Grade 
ORDER BY Grade;
GO

-- ========================================
-- 3. TOTAL STUDENTS BY EDUCATION LEVEL
-- ========================================
SELECT EducationLevel, COUNT(*) AS Total 
FROM Students 
GROUP BY EducationLevel 
ORDER BY EducationLevel;
GO

-- ========================================
-- 4. STUDENTS BETWEEN 4 AND 8 YEARS OLD
-- ========================================
SELECT EducationLevel, COUNT(*) AS Total 
FROM Students 
WHERE DATEDIFF(YEAR, DateOfBirth, GETDATE()) BETWEEN 4 AND 8 
GROUP BY EducationLevel 
ORDER BY EducationLevel;
GO

-- ========================================
-- 5. SIBLING GROUPS (SAME PARENTS)
-- ========================================
SELECT 
    FatherName, 
    MotherName, 
    COUNT(*) AS TotalSiblings,
    STRING_AGG(FullName, ', ') AS StudentNames
FROM Students 
GROUP BY FatherName, MotherName 
HAVING COUNT(*) > 1 
ORDER BY TotalSiblings DESC, FatherName, MotherName;
GO

-- ========================================
-- ADDITIONAL USEFUL QUERIES
-- ========================================

-- Students by Address Type
SELECT 
    CASE AddressType 
        WHEN 0 THEN 'Billing'
        WHEN 1 THEN 'Residential' 
        WHEN 2 THEN 'Correspondence'
    END AS AddressType,
    COUNT(*) AS Total
FROM Students 
GROUP BY AddressType 
ORDER BY AddressType;
GO

-- Age Distribution
SELECT 
    DATEDIFF(YEAR, DateOfBirth, GETDATE()) AS Age,
    COUNT(*) AS TotalStudents
FROM Students 
GROUP BY DATEDIFF(YEAR, DateOfBirth, GETDATE())
ORDER BY Age;
GO

-- Students by Birth Month
SELECT 
    MONTH(DateOfBirth) AS BirthMonth,
    COUNT(*) AS TotalStudents
FROM Students 
GROUP BY MONTH(DateOfBirth)
ORDER BY BirthMonth;
GO

-- Complete Student Information Report
SELECT 
    StudentId,
    FullName,
    DATEDIFF(YEAR, DateOfBirth, GETDATE()) AS Age,
    Grade,
    EducationLevel,
    CASE AddressType 
        WHEN 0 THEN 'Billing'
        WHEN 1 THEN 'Residential' 
        WHEN 2 THEN 'Correspondence'
    END AS AddressType,
    Street + ', ' + Number + ', ZIP ' + ZipCode AS CompleteAddress,
    FatherName,
    MotherName
FROM Students 
ORDER BY Grade, FullName;
GO
