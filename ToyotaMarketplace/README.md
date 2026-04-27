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
8. Add "appsettings.json" file in the root of the project (if non-existent).
9. Add the connection string to the appsettings.json file.
  '''
    "ConnectionStrings": { // Remove TrustServerCertificate=True when moving to production (hosting the web app).
        "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ToyotaMarketplace;Trusted_Connection=True;TrustServerCertificate=True"
    },
  '''

10. Paste in the Package Manager Console "Install-Package Microsoft.EntityFrameworkCore.Tools"
11. Paste in the Package Manager Console "Install-Package Microsoft.EntityFrameworkCore.SqlServer"
  11.1 If didn't work, try "Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.0"
    11.1.1 If still didn't work, check your version.
12. Paste in Program.cs (after "var builder = WebApplication.CreateBuilder(args);"): 

'''
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
'''

13. Create a migration with the command "Add-Migration (name of migration)" in Package Manager Console
  e.g., Add-Migration AddUserSchema

## Seeding

# Installing Tailwind CSS


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