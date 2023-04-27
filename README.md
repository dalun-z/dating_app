# dating_app

## Frameworks: 
- .NET 7.0
- Angular
- EntityFramework
- Bootstrap

## Languages:
- HTML5
- CSS
- TypeScript
- C#

## Tools:
- `dotnet tool install --global dotnet-ef --version 7.0.5` [https://www.nuget.org/packages/dotnet-ef/]
- `dotnet ef` for more usage
- Used `SQLite` as test databse


# Configuration:
- To run the Back-End : 
    > `cd API`

    > `dotnet run` 


# Issue Encountered:
- `DefaultConnection` in both `appsettings.Development.json` file and `Program.cs` file has to be 100% same. Otherwise it will cause Database connection error
method: `opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));`

- Used `Async` and `Task` keyword to make HTTP request asynchronous. 
Usage: `public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }`
