### How to Run Backend:

#### Prerequisites:.Net core version 6
- Install the following NuGet Packages:
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Design
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.EntityFrameworkCore.Sqlite
  - XUnit
  - Moq

#### Steps:
1. Open your command line interface.
2. Execute the following commands:
<<<<<<< HEAD
cd BookManagement\BookManagement
dotnet run
=======
   ```bash
   cd BookManagement\BookManagement
   dotnet ef database update
   dotnet run

>>>>>>> 157a6dab7a929c3f21074486f1970d1d21ac7c29
Result:
The backend project will automatically run on https://localhost:5014/.

### How to Run Frontend:

#### Steps:
1. Open your command line interface.
2. Run the following command:
<<<<<<< HEAD
cd BookManagement\BookManagement.Client\book-management
npm i
ng serve

=======
   ```bash
   cd BookManagement\BookManagement.Client\book-management
   npm i
   ng serve
>>>>>>> 157a6dab7a929c3f21074486f1970d1d21ac7c29

Result:
The frontend project will automatically run on https://localhost:4200/ and connect to the backend project.
