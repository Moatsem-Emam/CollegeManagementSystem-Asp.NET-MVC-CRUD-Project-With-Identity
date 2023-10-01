# Online Shopping System

## Table of Contents
- [Description](#description)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Installation](#installation)
- [How To Run](#How-To-Run)
- [Screenshots/Demo](#screenshotsdemo)
- [Contact](#contact)

### Description

The College Management System is a web application built with ASP.NET Core MVC, designed to efficiently manage various aspects of a college or educational institution. This project includes features for managing students, courses, faculty, and administrative tasks. It also implements user authentication with role-based access control using ASP.NET Core Identity.

### Technologies Used

- **ASP.NET Core MVC:** The framework used for building the web application.
- **C#:** The primary programming language for developing the application logic.
- **ASP.NET Core Identity:** Used for user authentication and role management.
- **Entity Framework Core:** For database interaction and management.
- **LINQ:** Used for querying and manipulating data in the application.
- **SQL Server:** The relational database management system used for data storage.

### Features

- **User Authentication:** Secure user registration and login system with role-based access control (admin, faculty, student, etc.).
- **Manage Students:** Add, view, update, and delete student records.
- **Manage Courses:** Create, edit, and delete courses offered by the college.
- **Manage Faculty:** Add and manage faculty members' information.
- **Admin Dashboard:** A dedicated dashboard for administrators to oversee the system's functioning.
- **Database Integration:** Utilizes Entity Framework Core for database interaction and LINQ for querying data.
- **SQL Server:** The project employs SQL Server as the relational database for data storage.

### Installation

To run this project locally, follow these steps:

 1. Clone this repository to your local machine.
 2. https://github.com/yourusername/college-management-system.git
    ```bash
    git clone https://github.com/yourusername/college-management-system.git
 3. Navigate to the project directory.
    ```bash
    cd college-management-system
 4. Configure your database connection in the appsettings.json file.
 5. Apply database migrations to create the database schema.
    ```bash
    dotnet ef database update

### How To Run
#### 1. Go to solution files then Right click >> Properties >> Startup files
#### 2. Select this option to run multiple files 
![Screenshot (560)](https://github.com/Moatsem-Emam/OnlineShoppingSystem-Asp.NET-Consume-WebApi-CRUD-Project/assets/146538331/518cb12a-206f-4722-88c2-103fef1501b5)


### Screenshots/Demo
#### Model Diagram
![Screenshot 2023-09-11 223232](https://github.com/Moatsem-Emam/OnlineShoppingSystem-Asp.NET-Consume-WebApi-CRUD-Project/assets/146538331/571190c1-244c-42c2-93e1-9ee4f64c37a6)
#### Home Page
![Screenshot (487)](https://github.com/Moatsem-Emam/OnlineShoppingSystem-Asp.NET-Consume-WebApi-CRUD-Project/assets/146538331/d64de4f4-7413-4d21-a4ed-7e514b40529c)
#### Product Data
![Screenshot (497)](https://github.com/Moatsem-Emam/OnlineShoppingSystem-Asp.NET-Consume-WebApi-CRUD-Project/assets/146538331/bbca7511-f63b-4f9f-b7a9-29e39cdd0e0d)
#### Create Product
![Screenshot (498)](https://github.com/Moatsem-Emam/OnlineShoppingSystem-Asp.NET-Consume-WebApi-CRUD-Project/assets/146538331/36650324-248a-4d6e-b422-7173d1d7df7c)
#### Edit Product
![Screenshot (502)](https://github.com/Moatsem-Emam/OnlineShoppingSystem-Asp.NET-Consume-WebApi-CRUD-Project/assets/146538331/ceba4a37-d8b3-4a70-ba3b-fae7c7d8288c)
#### Details
![Screenshot (500)](https://github.com/Moatsem-Emam/OnlineShoppingSystem-Asp.NET-Consume-WebApi-CRUD-Project/assets/146538331/d46721fa-02a3-411e-8954-dfe2bcbc41b4)
#### Delete
![Screenshot (504)](https://github.com/Moatsem-Emam/OnlineShoppingSystem-Asp.NET-Consume-WebApi-CRUD-Project/assets/146538331/6d5a8a66-7b22-4b78-8de2-dec48247c9df)
## Contact

For any inquiries or feedback, you can reach out to [Motsememamhussain@gmail.com](mailto:Motsememamhussain@gmail.com) or connect with us on [GitHub](https://github.com/Moatsem-Emam).
