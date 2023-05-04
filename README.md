# dating_app Spec

## Frameworks/RunTime Enviornment: 
- .NET v7.0
- Angular v14.2.11
- EntityFramework
- Bootstrap v5
- node v18.16.0
- npm v9.5.1

-----

# ***Back-End Dev***

## Configuration:
- To run the Server: 
    > `cd API`
    
    > `dotnet run` 
    
    or

    > `dotnet watch | dotnet watch --no-hot-reload`

## Tools:
- `dotnet tool install --global dotnet-ef --version 7.0.5` [https://www.nuget.org/packages/dotnet-ef/]
- `dotnet ef` for more usage
- Used `SQLite` as test databse

## Packages/Dependencies:
- Check `/API/API.csproj` file

## Update SQLite Database
- Update in migration folder `dotnet ef migrations add UserPasswordAdded`
- Update database `dotnet ef database update`

## Issue Encountered:
- `DefaultConnection` in both `appsettings.Development.json` file and `Program.cs` file has to be 100% same. Otherwise it will cause Database connection error.
Method: `opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));`

- Used `Async` and `Task` keyword to make HTTP request asynchronous. 
Usage: `public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }`

----

# ***Front-End Dev***

## Configuration:
- To run the dating_app:
    - > `cd client`
    - > `ng serve`

## HTTPS Certificate on Angular
- `~/client/ssl`

## Issue Encountered:
- Angular environmnet setup issue:
    - Issue : `zsh: command not found : ng`
    - Fix : 
        - >`npm uninstall -g angular-cli@14`
        - >`npm list -g`
        - >`sudo npm cache clean --f` 
        - >`npm install -g @angular/cli@14`
        - >`npm config get prefix    // output=/usr/local/lib/node_modules/.npm-i9nnxROI`
        - >`alias ng="/usr/local/lib/node_modules/.npm-i9nnxROI/bin/ng"`
        - >`ng version`
- `ngx-bootstrap` & `bootstrap` dependencies
    - Issue : ngx-bootstrap has updated to v10 which is not compatiable with angular v14. So Either `ng add ngx-bootstrap` or `npm install ngx-bootstrap --save` won't work 
    - Fix :
        - > `npm install ngx-bootstrap@9`
        - > `npm install bootstrap@5`
    
