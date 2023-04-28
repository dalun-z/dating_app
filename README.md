# dating_app

## Frameworks: 
- .NET v7.0
- Angular v14.2.11
- EntityFramework
- Bootstrap

## Languages:
- HTML5
- CSS
- TypeScript
- C#

# Back-End Dev

## Tools:
- `dotnet tool install --global dotnet-ef --version 7.0.5` [https://www.nuget.org/packages/dotnet-ef/]
- `dotnet ef` for more usage
- Used `SQLite` as test databse


## Packages/Dependencies:
- Check `/API/API.csproj` file


## Configuration:
- To run the Back-End : 
    > `cd API`

    > `dotnet run` 

## Issue Encountered:
- `DefaultConnection` in both `appsettings.Development.json` file and `Program.cs` file has to be 100% same. Otherwise it will cause Database connection error.
Method: `opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));`

- Used `Async` and `Task` keyword to make HTTP request asynchronous. 
Usage: `public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }`

# Front-End Dev



## Issue Encountered:
- Angular environmnet setup issue:
    - Issue : `zsh: command not found : ng`
    - Fix : 
        - `npm uninstall -g angular-cli@14`
        - `npm list -g`
        - `sudo npm cache clean --f` 
        - `npm install -g @angular/cli@14`
        - `ng version`

    
