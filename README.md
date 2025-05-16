1. Build a Simple Task Management API
=======================================
 Task Management API (.NET Core)

A simple task management REST API built using ASP.NET Core Web API, featuring JWT authentication, role-based access, and SQL Server database.

Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)
- Visual Studio 2022+

 Prerequisites

Ensure the following tools are installed on your machine:

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-in/sql-server/sql-server-downloads)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/)
- [Postman](https://www.postman.com/) – for API testing

Step 1: Clone the Repository

git clone https://github.com/your-username/task-management-api.git
cd task-management-api

POSTMAN :

https://crimson-flare-1295-1.postman.co/workspace/My-Workspace~da3ab48d-bf00-4f4a-842c-50e1d02a0e59/collection/32994714-6189d2b4-5b48-43e9-8bb0-29cc2baef776?action=share&creator=32994714

For Post Methods you will find the data in Body>>Raw

 Step 2: Update the Connection String
Edit the appsettings.json file and set your SQL Server instance:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_USER_NAME;User Id=DATABASE_ID;Password=PASSWORD;MultipleActiveResultSets=true;TrustServerCertificate=True;"
}
 Step 3: Apply Migrations & Create the Database
Option A: First-Time Migration
bash

dotnet ef migrations add InitialCreate
dotnet ef database update
Option B: If Migration Already Exists
dotnet ef database update
Option C: To Reset Migration
Delete the Migrations/ folder from the solution.

Then re-run:
dotnet ef migrations add InitialCreate
dotnet ef database update
Use Developer PowerShell for Visual Studio or terminal at project root.


 Step 4: Run the Project
dotnet run
Visit: https://localhost:5001/swagger to explore the API.

Step 5: Seed Sample Data
After the database and tables are created, use SQL Server to run the following SQL script:
-- Insert Users
INSERT INTO Users (Username, Password, Role)
VALUES 
('AdminUser', 'adminpass', 'Admin'),
('Developer1', 'devpass1', 'User'),
('Tester1', 'testpass1', 'User');

-- Insert Tasks
INSERT INTO Tasks (Title, Description, UserId)
VALUES 
('Implement Login', 'Create login flow with JWT tokens', 1),
('Build Dashboard UI', 'Design and code dashboard', 2),
('Write Unit Tests', 'Add tests for services layer', 3);

-- Insert Comments
INSERT INTO TaskComments (Comment, TaskItemId, UserId)
VALUES 
('Started implementing JWT login logic.', 1, 1),
('Backend auth API is ready.', 1, 2), 
('Draft UI screens uploaded.', 2, 2),
('Looks good, waiting for integration.', 2, 3),
('Wrote tests for user service.', 3, 3),
('Please increase coverage above 80%.', 3, 1);

 Step 6: Authenticate & Get Token
Use Postman to send a POST request to:

POST /api/auth/login
Example body:

{
  "username": "AdminUser",
  "password": "adminpass"
}
Copy the JWT token from the response.

Add the token in Postman headers for protected endpoints:

Authorization: Bearer <your_token>

Step 7: Test API Endpoints in Postman
Method Endpoint Description
POST /api/auth/login Generate JWT Token
GET /api/tasks/{id} Get Task by ID
GET /api/tasks/user/{id} Get Tasks by User
POST /api/tasks Create a New Task

====================================
2. Database Design Basics

ER diagram file attached 
select * from TaskComments 
select * from Users
Select * from Tasks
=================================
3. Debugging & Code Fixing
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TaskService
{
    private readonly DbContext _dbContext;

    public TaskService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TaskItem> GetTaskAsync(int id)
    {
        return await _dbContext.Set<TaskItem>().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<TaskItem>> GetAllTasksAsync()
    {
        return await _dbContext.Set<TaskItem>().ToListAsync();
    }
}


Explanation note: 
1.Task is a reserved system type. Your entity class should not be named Task
2.Async methods must return Task<T> to support await
3.Async methods must use await for async DB calls
4._dbContext base type doesn't have a Tasks property unless explicitly declared in a derived DbContext
