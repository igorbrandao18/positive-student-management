# 🎓 Positive Student Management System

A **professional-grade** student management system built with **ASP.NET Core MVC**, featuring **clean architecture**, **modular design**, and **modern UI**.

## ✨ Features

### 🏗️ **Architecture & Design**
- **Clean Architecture**: Separation of concerns with Service Layer pattern
- **Modular CSS**: Component-based styling system
- **Dependency Injection**: Testable and maintainable code
- **Repository Pattern**: Ready for data access abstraction
- **FluentValidation**: Custom validation rules

### 📚 **Student Management**
- **Complete CRUD**: Create, Read, Update, Delete operations
- **Auto ID Generation**: Sequential student ID with format `STU0000001`
- **Age-Grade Validation**: Ensures student age matches selected grade
- **Education Level**: Automatic calculation based on grade
- **Address Management**: Multiple address types (Billing, Residential, Correspondence)
- **Parent Tracking**: Father and mother information

### 📊 **Reporting & Analytics**
- **Total Students Count**: Real-time statistics
- **Students by Grade**: Distribution with percentages
- **Students by Education Level**: Academic level breakdown
- **Age Range Analysis**: Students between 4-8 years
- **Siblings Identification**: Grouped by parent information

### 🎨 **Modern UI/UX**
- **Responsive Design**: Mobile-first approach
- **Component-Based CSS**: Modular and maintainable styles
- **Bootstrap 5**: Professional UI components
- **Custom Design System**: Consistent colors, spacing, and typography
- **Interactive Elements**: Hover effects and smooth transitions

## 🛠️ Technology Stack

### **Backend**
- **ASP.NET Core 8.0**: Latest framework with performance improvements
- **Entity Framework Core**: ORM with code-first approach
- **SQL Server**: Enterprise-grade database
- **FluentValidation**: Advanced validation framework
- **Dependency Injection**: Built-in IoC container

### **Frontend**
- **Razor Pages**: Server-side rendering
- **Bootstrap 5**: CSS framework
- **Custom CSS Architecture**: Modular component system
- **Responsive Design**: Mobile and desktop optimized

### **DevOps**
- **Docker**: Containerization
- **Docker Compose**: Multi-container orchestration
- **Git**: Version control
- **GitHub**: Repository hosting

## 🚀 Quick Start

### **Prerequisites**
- Docker Desktop
- Git

### **Running with Docker**

1. **Clone the repository**
   ```bash
   git clone https://github.com/igorbrandao18/positive-student-management.git
   cd positive-student-management
   ```

2. **Run with Docker Compose**
   ```bash
   cd Docker
   docker-compose up --build
   ```

3. **Access the application**
   - **Application**: http://localhost:8083
   - **Database**: localhost:1435

## 📁 Project Structure

```
PositiveStudentManagement/
├── Controllers/           # MVC Controllers (thin layer)
├── Services/             # Business Logic Layer
│   ├── IStudentService.cs
│   └── StudentService.cs
├── ViewModels/           # View-Specific Models
│   ├── ReportsViewModel.cs
│   └── StudentFormViewModel.cs
├── Models/               # Domain Models
│   └── Student.cs
├── Data/                 # Entity Framework Context
│   └── ApplicationDbContext.cs
├── Validators/           # FluentValidation Rules
│   └── StudentValidator.cs
├── Helpers/              # Utility Classes
│   └── StudentHelper.cs
├── Constants/            # Application Constants
│   └── StudentConstants.cs
├── Views/                # Razor Views
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── Partials/     # Reusable Components
│   ├── Home/
│   └── Students/
├── wwwroot/              # Static Files
│   ├── css/
│   │   ├── components/   # Reusable CSS Components
│   │   ├── pages/        # Page-Specific Styles
│   │   ├── utilities/    # CSS Variables & Utilities
│   │   └── main.css      # Main Import File
│   └── js/
├── Database/             # Database Scripts
│   └── Scripts/
├── Docker/               # Container Configuration
│   ├── Dockerfile
│   └── docker-compose.yml
└── Docs/                 # Documentation
    └── ARCHITECTURE.md
```

## 🎯 Architecture Benefits

### **Separation of Concerns**
- **Controllers**: Handle HTTP requests/responses only
- **Services**: Contain business logic
- **Models**: Domain entities with validation
- **ViewModels**: View-specific data transfer objects

### **Maintainability**
- **Modular CSS**: Easy to locate and modify styles
- **Service Layer**: Reusable business logic
- **Constants**: Centralized configuration
- **Helpers**: Utility functions

### **Testability**
- **Dependency Injection**: Easy to mock dependencies
- **Service Interfaces**: Contract-based testing
- **Separation**: Each layer can be tested independently

### **Scalability**
- **Repository Pattern**: Ready for data access abstraction
- **Service Layer**: Easy to add new business logic
- **Modular Design**: Components can be extended independently

## 📊 Student Model

### **Personal Information**
- **Full Name**: Required, 2-100 characters
- **Date of Birth**: Required, must be in the past
- **Age**: Calculated automatically
- **Student ID**: Auto-generated (`STU0000001` format)

### **Academic Information**
- **Grade**: Required, from G1 to 12th Grade
- **Education Level**: Computed automatically
  - **Infant**: G1, G2, G3 (3-5 years)
  - **Early Years**: 1st-5th Grade (6-10 years)
  - **Later Years**: 6th-9th Grade (11-14 years)
  - **High School**: 10th-12th Grade (15-17 years)

### **Address Information**
- **Address Type**: Billing, Residential, or Correspondence
- **Street**: Required, max 150 characters
- **Number**: Required, max 20 characters
- **ZIP Code**: Required, max 10 characters
- **Complement**: Optional, max 100 characters

### **Family Information**
- **Father's Name**: Required, 2-100 characters
- **Mother's Name**: Required, 2-100 characters

## ✅ Validation Rules

### **Business Rules**
- **Age vs Grade**: Automatic validation ensures age matches grade
- **Required Fields**: All mandatory fields validated
- **Data Integrity**: Database constraints and business rules
- **Format Validation**: Names, addresses, ZIP codes

### **Custom Validation**
- **FluentValidation**: Advanced validation framework
- **Custom Rules**: Age-grade compatibility
- **Error Messages**: User-friendly validation messages
- **Server & Client**: Both server and client-side validation

## 📈 Reports Available

1. **Total Students Count**: Real-time statistics
2. **Students by Grade**: Distribution with percentages
3. **Students by Education Level**: Academic level breakdown
4. **Students Between 4-8 Years**: Detailed age analysis
5. **Siblings Identification**: Grouped by parent information

## 🔗 API Endpoints

### **Student Management**
- `GET /` - Home page with statistics
- `GET /Students` - List all students
- `GET /Students/Create` - Create new student form
- `POST /Students/Create` - Create student
- `GET /Students/Edit/{id}` - Edit student form
- `POST /Students/Edit/{id}` - Update student
- `GET /Students/Details/{id}` - Student details
- `GET /Students/Delete/{id}` - Delete confirmation
- `POST /Students/Delete/{id}` - Delete student
- `GET /Students/Reports` - Reports and analytics

## 🛠️ Development

### **Local Development**

1. **Install .NET 8.0 SDK**
2. **Install SQL Server**
3. **Update connection string** in `appsettings.json`
4. **Run the application**
   ```bash
   dotnet run
   ```

### **Database Setup**

The application automatically creates the database and seeds initial data on first run.

### **Adding New Features**

1. **Create Service Interface** in `Services/`
2. **Implement Service** with business logic
3. **Register Service** in `Program.cs`
4. **Update Controller** to use service
5. **Add Validation** if needed
6. **Create ViewModels** for complex views

## 🧪 Testing Strategy

### **Unit Tests** (Future)
- **Service Layer**: Business logic testing
- **Validators**: Validation rule testing
- **Helpers**: Utility method testing

### **Integration Tests** (Future)
- **Controllers**: End-to-end testing
- **Database**: Data access testing
- **API**: HTTP endpoint testing

## 🚀 Deployment

### **Docker**
- **Multi-stage builds**: Optimized images
- **Environment variables**: Configuration management
- **Health checks**: Container monitoring
- **Volume mounts**: Data persistence

### **Production Considerations**
- **Environment-specific configs**: `appsettings.Production.json`
- **Logging**: Structured logging
- **Monitoring**: Application insights
- **Scaling**: Horizontal scaling ready

## 📚 Documentation

- **[Architecture Documentation](Docs/ARCHITECTURE.md)**: Detailed technical documentation
- **Code Comments**: Comprehensive inline documentation
- **API Documentation**: Endpoint specifications

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Team

- **Developer**: Igor Brandão
- **Email**: igorbrandao18@gmail.com
- **GitHub**: [@igorbrandao18](https://github.com/igorbrandao18)

## 🙏 Acknowledgments

- **ASP.NET Core Team**: For the amazing framework
- **Bootstrap Team**: For the CSS framework
- **Entity Framework Team**: For the ORM
- **Docker Team**: For containerization technology

---

**Built with ❤️ using ASP.NET Core MVC**