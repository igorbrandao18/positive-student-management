# 📚 API Documentation

## Overview

The Positive Student Management System provides a comprehensive REST API for managing student data. All endpoints return JSON responses and follow RESTful conventions.

## Base URL

- **Development**: `http://localhost:8084`
- **Production**: `https://your-domain.com`

## Authentication

Currently, the API does not require authentication. In production, implement proper authentication mechanisms.

## Endpoints

### 🏠 Home

#### Get Dashboard Statistics
```http
GET /
```

**Response:**
```json
{
  "totalStudents": 10,
  "systemStatus": "Online",
  "features": "Complete"
}
```

### 👥 Students

#### Get All Students
```http
GET /Students
```

**Response:**
```json
[
  {
    "id": 1,
    "studentId": "STU0000001",
    "fullName": "John Smith",
    "dateOfBirth": "2018-05-10T00:00:00",
    "age": 6,
    "grade": "G2",
    "educationLevel": "Infant",
    "addressType": "Residential",
    "street": "123 Main St",
    "zipCode": "12345",
    "number": "1A",
    "complement": "Apt 101",
    "fatherName": "Robert Smith",
    "motherName": "Mary Smith"
  }
]
```

#### Get Student by ID
```http
GET /Students/Details/{id}
```

**Parameters:**
- `id` (int): Student ID

**Response:**
```json
{
  "id": 1,
  "studentId": "STU0000001",
  "fullName": "John Smith",
  "dateOfBirth": "2018-05-10T00:00:00",
  "age": 6,
  "grade": "G2",
  "educationLevel": "Infant",
  "addressType": "Residential",
  "street": "123 Main St",
  "zipCode": "12345",
  "number": "1A",
  "complement": "Apt 101",
  "fatherName": "Robert Smith",
  "motherName": "Mary Smith"
}
```

#### Create New Student
```http
POST /Students/Create
Content-Type: application/json
```

**Request Body:**
```json
{
  "fullName": "Jane Doe",
  "dateOfBirth": "2015-09-20T00:00:00",
  "grade": "3rd Grade",
  "addressType": "Residential",
  "street": "456 Oak Ave",
  "zipCode": "67890",
  "number": "2B",
  "complement": null,
  "fatherName": "John Doe",
  "motherName": "Mary Doe"
}
```

**Response:**
```json
{
  "id": 11,
  "studentId": "STU0000011",
  "fullName": "Jane Doe",
  "dateOfBirth": "2015-09-20T00:00:00",
  "age": 9,
  "grade": "3rd Grade",
  "educationLevel": "Early Years",
  "addressType": "Residential",
  "street": "456 Oak Ave",
  "zipCode": "67890",
  "number": "2B",
  "complement": null,
  "fatherName": "John Doe",
  "motherName": "Mary Doe"
}
```

#### Update Student
```http
POST /Students/Edit/{id}
Content-Type: application/json
```

**Parameters:**
- `id` (int): Student ID

**Request Body:** Same as Create Student

**Response:** Updated student object

#### Delete Student
```http
POST /Students/Delete/{id}
```

**Parameters:**
- `id` (int): Student ID

**Response:**
```json
{
  "success": true,
  "message": "Student deleted successfully"
}
```

### 📊 Reports

#### Get Student Reports
```http
GET /Students/Reports
```

**Response:**
```json
{
  "totalStudents": 10,
  "studentsByGrade": [
    {
      "grade": "G2",
      "total": 2
    },
    {
      "grade": "3rd Grade",
      "total": 2
    }
  ],
  "studentsByEducationLevel": [
    {
      "educationLevel": "Infant",
      "total": 2
    },
    {
      "educationLevel": "Early Years",
      "total": 2
    }
  ],
  "studentsBetween4And8Years": [
    {
      "fullName": "John Smith",
      "age": 6,
      "educationLevel": "Infant"
    }
  ],
  "siblings": [
    {
      "fatherName": "Robert Smith",
      "motherName": "Mary Smith",
      "count": 2,
      "students": ["John Smith", "Daniel Miller"]
    }
  ]
}
```

## Error Responses

### 400 Bad Request
```json
{
  "error": {
    "message": "An error occurred while processing your request.",
    "details": "Student's age does not match the selected grade.",
    "timestamp": "2024-01-15T10:30:00Z",
    "path": "/Students/Create",
    "method": "POST"
  }
}
```

### 404 Not Found
```json
{
  "error": {
    "message": "An error occurred while processing your request.",
    "details": "Student not found",
    "timestamp": "2024-01-15T10:30:00Z",
    "path": "/Students/Details/999",
    "method": "GET"
  }
}
```

### 500 Internal Server Error
```json
{
  "error": {
    "message": "An error occurred while processing your request.",
    "details": "Database connection failed",
    "timestamp": "2024-01-15T10:30:00Z",
    "path": "/Students",
    "method": "GET"
  }
}
```

## Data Models

### Student
```json
{
  "id": "integer",
  "studentId": "string (format: STU0000001)",
  "fullName": "string (2-100 characters)",
  "dateOfBirth": "datetime (ISO 8601)",
  "age": "integer (calculated)",
  "grade": "string (G1, G2, G3, 1st Grade, ..., 12th Grade)",
  "educationLevel": "string (Infant, Early Years, Later Years, High School)",
  "addressType": "string (Billing, Residential, Correspondence)",
  "street": "string (max 150 characters)",
  "zipCode": "string (max 10 characters)",
  "number": "string (max 20 characters)",
  "complement": "string (max 100 characters, optional)",
  "fatherName": "string (2-100 characters)",
  "motherName": "string (2-100 characters)"
}
```

## Validation Rules

### Student Creation/Update
- **Full Name**: Required, 2-100 characters
- **Date of Birth**: Required, must be in the past, student must be younger than 25 years
- **Grade**: Required, must be valid grade (G1-G3, 1st-12th Grade)
- **Address Type**: Required, must be valid type
- **Street**: Required, max 150 characters
- **ZIP Code**: Required, max 10 characters
- **Number**: Required, max 20 characters
- **Complement**: Optional, max 100 characters
- **Father's Name**: Required, 2-100 characters
- **Mother's Name**: Required, 2-100 characters
- **Age vs Grade**: Student's age must match the selected grade

### Grade-Age Validation
- **G1, G2, G3**: 3-5 years
- **1st-5th Grade**: 6-10 years
- **6th-9th Grade**: 11-14 years
- **10th-12th Grade**: 15-17 years

## Rate Limiting

Currently, no rate limiting is implemented. In production, implement appropriate rate limiting.

## Caching

- Student lists are cached for 15 minutes
- Individual student data is cached for 30 minutes
- Reports are cached for 10 minutes

## Health Checks

### Application Health
```http
GET /health
```

**Response:**
```json
{
  "status": "Healthy",
  "checks": [
    {
      "name": "database",
      "status": "Healthy",
      "description": "Database is healthy. Total students: 10"
    },
    {
      "name": "application",
      "status": "Healthy",
      "description": "Application is healthy",
      "data": {
        "memory_usage_mb": 45.2,
        "uptime": 3600,
        "timestamp": "2024-01-15T10:30:00Z"
      }
    }
  ]
}
```

## Examples

### Create a New Student
```bash
curl -X POST http://localhost:8084/Students/Create \
  -H "Content-Type: application/json" \
  -d '{
    "fullName": "Alice Johnson",
    "dateOfBirth": "2016-03-15T00:00:00",
    "grade": "2nd Grade",
    "addressType": "Residential",
    "street": "789 Pine Street",
    "zipCode": "54321",
    "number": "3C",
    "fatherName": "Bob Johnson",
    "motherName": "Carol Johnson"
  }'
```

### Get Student Reports
```bash
curl http://localhost:8084/Students/Reports
```

### Check Application Health
```bash
curl http://localhost:8084/health
```
