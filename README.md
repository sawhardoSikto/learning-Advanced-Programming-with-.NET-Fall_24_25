# 🎓 UniMS - University Management System API

A complete University Management System built using ASP.NET Core Web API with 3-Layer Architecture, JWT Authentication, and Role-based Authorization.

---

## 🚀 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- JWT Authentication
- SMTP Email Service
- 3-Layer Architecture (DAL, BLL, API)

---

## 🏗️ Architecture

### 📂 Layers

**1. DAL (Data Access Layer)**
- Repositories
- DbContext
- DataAccessFactory
- Database operations

**2. BLL (Business Logic Layer)**
- Services
- CGPA calculation logic
- Enrollment validation
- Email sending logic
- Status update logic

**3. API Layer**
- Controllers
- Authentication endpoints
- Role-based authorization

---

## 👥 Roles

| Role     | Access |
|----------|--------|
| Admin    | Create users, manage system |
| Student  | View dashboard, results |
| Teacher  | Manage grades |

---

## 🔐 Authentication & Authorization

- JWT Token based Authentication
- Role-based Authorization
- Admin creates user accounts
- No public signup

---

## 📚 Core Features

### ✅ Student
- View dashboard
- View enrolled courses
- View grades
- Automatic CGPA calculation
- Auto status update (Active / Probation)
- Email notification if CGPA < 2.50

### ✅ Admin
- Create system users
- Manage departments
- Manage courses
- Manage teachers

### ✅ Teacher
- Update student grades

---

## 📊 Business Logic

- Student cannot enroll same course in same semester twice
- CGPA automatically calculated
- Student status updated based on CGPA
- Email sent when student goes to probation

---

## 🔒 Security Features

- JWT Bearer Authentication
- Role-based Authorization
- Secure SMTP email configuration
- Layered Architecture separation

---

## 📌 Future Improvements

- Refresh Token Implementation
- Password Hashing (BCrypt)
- Logging (Serilog)
- Pagination
- Filtering & Searching
- Deployment (Azure / Docker)

---

## 🧠 Learning Outcomes

- Clean Architecture
- Repository Pattern
- Dependency Injection
- JWT Authentication
- Role-based Authorization
- Email Integration
- Advanced Business Logic

---

## 👨‍💻 Author

Developed as a learning-based industry-style project to understand real-world API architecture and authentication system.
