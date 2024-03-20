How to Run Backend:
Prerequisites: .Net Core version 6
- Install the following NuGet Packages:
 + Microsoft.EntityFrameworkCore
 + Microsoft.EntityFrameworkCore.Design
 + Microsoft.EntityFrameworkCore.Tools
 + Microsoft.EntityFrameworkCore.Sqlite
 + XUnit
 + Moq
Steps:
1. Open your command line interface.
2. Execute the following commands:
cd BookManagement\BookManagement
dotnet run
Result:
The backend project will automatically run on https://localhost:5014/.


How to Run Frontend:
Steps:
1. Open your command line interface.
2. Run the following command:
cd BookManagement\BookManagement.Client\book-management
npm i
ng serve


Result:
The frontend project will automatically run on https://localhost:4200/ and connect to the backend project.