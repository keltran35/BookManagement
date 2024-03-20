Install Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Sqlite

dotnet ef migrations add InitialCreate -o Data/Migrations
dotnet ef database update

install extension SQLite
ctrl p > SQLite: Open database
choose the first

dotnet run