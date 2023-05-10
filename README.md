# A Dating App 

## Frameworks/RunTime Enviornment: 
- .NET v7.0
- Angular v14.2.11
- Entity Framework Core 6.0
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
- To run the Database in VScode:
    > `cmd` + `p`
    
    > `>SQLite`

## Features:
- Server will receive updated user information into database and also return to the web app

## Tools:
- `dotnet tool install --global dotnet-ef --version 7.0.5`
- [dotnet-ef](https://www.nuget.org/packages/dotnet-ef/)
- Used `SQLite` as test databse

## Packages/Dependencies:
- Check `/API/API.csproj` file

## Update SQLite Database
- Update in migration folder `dotnet ef migrations add UserPasswordAdded`
- Update database `dotnet ef database update`
- Remove added migration folder BEFORE update database `dotnet ef migrations remove`

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

## Tools:
- [@ngx-bootstrap](https://github.com/valor-software/ngx-bootstrap)
- [@ngx-toastr ](https://github.com/scttcper/ngx-toastr)
- [bootswatch](https://bootswatch.com/)
- [@ngx-gallery](https://www.npmjs.com/package/@kolkov/ngx-gallery)
- ~~[@ngx-spinner](https://www.npmjs.com/package/ngx-spinner)~~

## Features:
- Users are able to view, like, send messages to other users on the web app
- Update profile page(Description, City, Age, Country, Photos and etc..)
- Users will be alert if the user accidently click on other tab or heading to other website after made changes in `edit` page 
- Alert for user to nitify them if they made any changes to their profile or any error
- ~~`loading` feature in web app~~

## Issue Encountered:
- Angular environmnet setup issue:
    - Issue : `zsh: command not found : ng`
    - Fix : 
    ```
        npm uninstall -g angular-cli@14
        npm list -g
        sudo npm cache clean --f
        npm install -g @angular/cli@14
        npm config get prefix    // output=/usr/local/lib/node_modules/.npm-i9nnxROI
        alias ng="/usr/local/lib/node_modules/.npm-i9nnxROI/bin/ng"
        ng version
    ```
- `ngx-bootstrap` & `bootstrap` dependencies
    - Issue : ngx-bootstrap has updated to v10 which is not compatiable with angular v14. So Either `ng add ngx-bootstrap` or `npm install ngx-bootstrap --save` won't work 
    - Fix :
        - > `npm install ngx-bootstrap@9`
        - > `npm install bootstrap@5`
- `ngx-toastr` compile error
    - Fix : `npm install ngx-toastr@~14.0.0`
- use `pipe()` method to modify Observable
- Angualar package supporting current npm version but hasn't released the update yet
    After `npm install ngx-spinner`
    - Issue: 
        - `npm ERR! code ERESOLVE`
        - `npm ERR! ERESOLVE unable to resolve dependency tree`
    - Fix : `npm install ngx-spinner --legacy-peer-deps`