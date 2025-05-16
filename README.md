
## 🛠️ Technologies

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger
- Visual Studio

---

## 📦 Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-in/sql-server/sql-server-downloads)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- [Postman](https://www.postman.com/) for API testing

step 1 : 
Clone the project 

Step 2 : 
Update Connection String
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TaskDb;Trusted_Connection=True;TrustServerCertificate=True;"
}  
OR
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_USER_NAME;User Id=DATABASE_ID;Password=PASSWORD;MultipleActiveResultSets=true;TrustServerCertificate=True;"
}
Step 3 : 
Apply Migrations & Create Database 
open Developer powershell and run the followig commands 
dotnet ef migrations add InitialCreate
dotnet ef database update
======== or =========
If already the migration file exists run the following 
dotnet ef database update
else 
Delete the migration file from the solution and re-run the following commands
dotnet ef migrations add InitialCreate
dotnet ef database update

step 4 : 
Run the Project
dotnet run

Step 5: 
Open SQL Server to check if tables are created 
Run the following Script to insert data and test the apis
---------------------------------------------------------------------
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
------------------------------------------------------------

Step 6 : 
Call the /api/auth/login endpoint with credentials.
Copy the returned JWT token.
Use the token in Postman by adding a header:
Authorization: Bearer <your_token>

Step 7 : 
📑 API Endpoints
POST api/Auth/login as GenerateToken in postman 
GET  api/Tasks/{id} as GetTaskByID  in postman  
GET api/Tasks/user/{id} as GetTaskByUser in postman 
POST api/Tasks as CreateTask in Postman 









