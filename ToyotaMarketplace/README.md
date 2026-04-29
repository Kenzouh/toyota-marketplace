# Setting up the MVC architecture:

1. Pick "MVC" from the dropdown menu in the top right corner of the project.
2. Create "Areas" folder.
3. Right Click Areas -> Press "Add" -> Press "Area..." -> Name it "Public".
4. Repeat step 3, but create "Admin" area instead of Public.
5. In Program.cs, replace "app.MapControllerRoute" block with this block (for default navigation):

'''
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { area = "Public", controller = "Home", action = "Homepage" });
'''

# Creating DB and seeding



# Setting up the MVC Architecture:

1. Pick "MVC" from the dropdown menu in the top right corner of the project.
2. Create "Areas" folder.
3. Right Click Areas -> Press "Add" -> Press "Area..." -> Name it "Public".
4. Repeat step 3, but create "Admin" area instead of Public.
5. In Program.cs, replace "app.MapControllerRoute" block with this block (for default navigation):

'''
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { area = "Public", controller = "Home", action = "Homepage" });
'''

# Creating DB and seeding

## Creating DB and Data/ApplicationDbContext.cs

1. Create a "Models" folder in the root.
2. Create a .cs file.
  2.1 Add the properties.
  2.2 Add the foreign keys (if applicable)
  2.3 Add the connections of the tables to one another (if has FKs)

3. Create a "Data" folder in the Areas folder.
4. Add "ApplicationDbContext.cs" file in the Data folder.
5. Add "using ToyotaCars.Models.Users;" to the top of ApplicationDbContext.cs file for referencing the User folder's files.
6. Add "DbSet<User> Users { get; set; }" to the ApplicationDbContext class for creating a table for users in the database (repeat this process for other models).
7. Add "modelBuilder" for creating relationships.
8. In Microsoft SQL Server app, make sure that the fields are filled up:

  '''
  - `Server type`: Database Engine (Default)
  - `Server name`: (localdb)\MSSQLLocalDB
  - `Authentication`: Windows Authentication (Default)
    - `User name`: Your Pc name/Windows Username (Default)
    - `Password`: Leave it blank (Default)
  - `Encryption`: Mandatory (Default)
    - `Trust server certificate`: Yes (Default)` 
  '''
  
9. Add "appsettings.json" file in the root of the project (if non-existent).
10. Add the connection string to the appsettings.json file.
 
  '''
    "ConnectionStrings": { // Remove TrustServerCertificate=True when moving to production (hosting the web app).
        "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ToyotaMarketplace;Trusted_Connection=True;TrustServerCertificate=True"
    },
  '''

11. Paste in the Package Manager Console "Install-Package Microsoft.EntityFrameworkCore.Tools"
12. Paste in the Package Manager Console "Install-Package Microsoft.EntityFrameworkCore.SqlServer"
  12.1 If didn't work, try "Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.0"
    12.1.1 If still didn't work, check your version.
13. Paste in Program.cs (after "var builder = WebApplication.CreateBuilder(args);"): 

'''
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
'''

14. Create a migration with the command "Add-Migration (name of migration)" in Package Manager Console
  e.g., Add-Migration AddUserSchema

## Seeding

1. Under `Data` folder, create `Seeds` folder.
2. Create a .cs file for seeding.
  e.g., VehicleTypeSeed.cs
3. Create an instance of the model you want to seed and add the properties.
  e.g., `new VehicleType { VehicleTypeName = "Hatchbacks & Sedans", Wheel = 4 }`

4. Don't forget to add `context.SaveChanges();` after seeding in the Seed.cs file.

5. Add in program.cs:

```
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Call the Seed() method for each seeeding class to populate the DB with initial data.
    VehicleTypeSeed.Seed(context); 
    VehicleModelSeed.Seed(context);
}
```

6. Execute the program in Visual Studio.

Note: The seed only works if the DB table is empty.

# Installing Tailwind CSS

1. `cd C:\Users\Chu\source\repos\tne2\ToyotaMarketplace\ToyotaMarketplace`
2. Paste in the Developer Powershell: `npm init -y`
3. Install Tailwind, paste in the Developer Powershell: `npm install -D tailwindcss`
4. Initialize Tailwind: `npx tailwindcss init`
5. In the tailwind.config.js file, add the content property (for connecting to areas and views):

```
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Views/**/*.cshtml",
    "./Areas/**/*.cshtml",
    "./Pages/**/*.cshtml"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
```

6. Create a CSS file `site.css` in `wwwroot/css` folder and add the Tailwind directives:

```
@tailwind base;
@tailwind components;
@tailwind utilities;
```

7. Add `_Layout.cshtml` under `Areas/Public/Views/Shared` (Note: you need to do this per area. Example: Admin, User).

8. In `Areas/Public/Views/Shared/_Layout/cshtml`, paste the Tailwind CSS link code in the `<head>` tag for connecting the CSS file:
  e.g., `<link href="~/css/site.css" rel="stylesheet" />`

9. In each layout, for example, in `Areas/Public/Views/Home/Homepage`, paste this at the top part of the file for connecting the layout to the view:

```
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```

10. In package.json, add the build script for Tailwind CSS:

```
    "scripts": {
        "tw": "tailwindcss -i ./Styles/input.css -o ./wwwroot/css/site.css --watch" 
    },
```

This makes sure that the Tailwind CSS is compiled and the changes are reflected in the site.css file. You can run this command in the powershell to start the watch mode for Tailwind CSS. 
Whenever you make changes to your input.css file, it will automatically recompile and update the site.css file.

Not doing this will make you paste `tailwindcss -i ./Styles/input.css -o ./wwwroot/css/site.css --watch` every time in the Developer PowerShell.

11. Paste in the 


12. Execute the program and Tailwind will run now.

13. To stop the Tailwind execution, press `Ctrl + C` in the Developer PowerShell. To run it again, repeat `step 11`.

// "npm run tw" in powershell

# Git-related stuff


## gitignore

Reference link: https://betterstack.com/community/questions/gitignore-vs-project-template/ 

# Extensions

Install-Package Microsoft.EntityFrameworkCore -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.0

# Types of errors:

- CS0103: The name '' does not exist in the current context
  - Solution: Check typo or add "using" statement.
  
- CS0246: The type or namespace name '' could not be found (are you missing a using directive or an assembly reference?)
  - Solution: Check typo, add "using" statement, or add reference to the assembly.
  
- CS1002: ; expected
  - Solution: Add semicolon.

=== [Usually in ApplicationDbContext.cs] ===

- CS1061: "Vehicle' does not contain a definition for 'VehicleModels' and no accessible extension method "VehicleModels' accepting a first argument of type "Vehicle' could be found (are you missing a using directive or an
assembly reference?)
  - Solution: Check typo, add "using" statement, or add reference to the assembly. Also check if the method is static or not and if it's being called correctly.
    - Example solutions: public ICollection<Vehicle> Vehicles { get; set; }
    - Example solutions: public Vehicle Vehicle { get; set; }

- CS1519: Invalid token '\ in class, record, struct, or interface member declaration
  - Solution: Remove the extra `\` character or whatever is declared in the error.

- CS1525: Invalid expression term ")"
  - Solution: Remove the extra ','

- CS7036: There is no argument given that corresponds to the required parameter "context' of "VehicleModelSeed. Seed[ApplicationDbContext)"
  - Solution: add an argument value.
    e.g., from `VehicleModelSeed.Seed();` to `VehicleModelSeed.Seed(context);`.