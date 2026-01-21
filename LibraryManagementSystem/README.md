🧾 Project Description

This project is a Library Management System developed using ASP.NET Core Web API and Entity Framework Core.
It follows a clean three-tier architecture consisting of Data Access Layer (DAL), Business Logic Layer (BLL), and API layer.
The system allows managing categories, books, users, and borrowing workflows.
It also supports in-app notifications, late return fine calculation, and advanced searching features.
The goal of the project is to demonstrate proper architectural design along with meaningful functionalities beyond basic CRUD operations.

🏗️ Architecture Overview

DAL (Data Access Layer)
Handles database operations using Entity Framework Core and repositories.

BLL (Business Logic Layer)
Contains core logic such as borrow/return workflow, notifications, and fine calculation.

API Layer (APIApp)
Exposes RESTful endpoints to interact with the system.

⚙️ Environment & Tools

Framework: ASP.NET Core Web API

ORM: Entity Framework Core

Database: SQL Server

IDE: Visual Studio

API Testing Tool: Postman / Swagger

How to Run

Open the solution in Visual Studio

Restore NuGet packages

Update the database connection string (if needed)

Run the project

Open Swagger:

https://localhost:7071/swagger/index.html

✨ Key Functionalities

Category & Book management

User borrowing and returning workflow

In-app notifications (borrow, return, late return)

Late return fine logic (100 TK)

Advanced search (category with books)

Workflow automation using status changes

🔗 API Usability (Postman Endpoints)
🔹 Category APIs
GET    /api/category/all
GET    /api/category/{id}
POST   /api/category/create
PUT    /api/category/update
POST   /api/category/delete/{id}
GET    /api/category/search/{name}
GET    /api/category/search/{name}/books

🔹 Book APIs
GET    /api/book/all
GET    /api/book/{id}
POST   /api/book/create
PUT    /api/book/update
POST   /api/book/delete/{id}

🔹 User APIs
GET    /api/user/all
GET    /api/user/{id}
POST   /api/user/create
PUT    /api/user/update
POST   /api/user/delete/{id}

🔹 Borrow APIs
POST   /api/borrow/borrow
PUT    /api/borrow/update
POST   /api/borrow/return/{borrowId}
GET    /api/borrow/all

🔹 Notification APIs
GET    /api/notification/all

🧪 Demo Tip (Important)

To demonstrate late return fine logic, the DueDate of a borrow record can be updated using the update endpoint to simulate a late return, after which returning the book will generate a fine notification.

🎓 Academic Purpose

This project was developed as part of an academic requirement to demonstrate:

Three-tier architecture

Clean separation of concerns

Repository & service pattern

Meaningful features beyond CRUD operations
