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


# Git-related stuff


## gitignore

Reference link: https://betterstack.com/community/questions/gitignore-vs-project-template/ 

# Extensions

Install-Package Microsoft.EntityFrameworkCore -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.0

# Other Details

## Car Colors Information:
  
### Beige

1. Beige Metallic (#ccb08c)
  - Grandia Tourer (Vans & Pick-ups)

### Black

1. Black
  - Raize (Crossovers & SUVs)
  - GR Corolla (Gazoo Racing)
  
2. Black 1 (#000000)
  - Vios (Hatchbacks & Sedans)
  - Innova (MPVs)
  - Tamaraw (Utility Vehicles)
  
3. Black 3 (#000000)
  - Super Grandia (Vans & Pick-ups)
  - Alphard (Vans & pick-ups)
  - Alphard (Electrified)
  
4. Black Metallic 1 (#000000)
  - Veloz (Crossovers & SUVs)
  - RAV4 (Crossovers & SUVs)
  - Rush (Crossovers & SUVs)
  - Avanza (MPVs)
  - Rush GR-S (Gazoo Racing)
  
5. Black Metallic 2 (#000000)
  - Avanza (MPVs)
  - GR Supra (Gazoo Racing)
  
6. Black Mica (#000000)
  - Land Cruiser Prado (Crossovers & SUVs)
  - GL Grandia (Vans & Pick-ups)
  
7. Altitude Black Mica (#000000)
  - RAV4 (Crossovers & SUVs)
  - RAV4 (Electrified)
  
8. Attitude Black Mica (#000000) 
  - ATIV (Hatchbacks & Sedans)
  - Camry (Hatchbacks & Sedans)
  - Corolla Altis (Hatchbacks & Sedans)
  - Yaris Cross (Crossovers & SUVs)
  - Corolla Cross (Crossovers & SUVs)
  - bZ4X (Crossovers & SUVs)
  - Fortuner (Crossovers & SUVs)
  - Land Cruiser (Crossovers & SUVs)
  - Zenix (MPVs)
  - Hilux (Vans & pick-ups)
  - Yaris Cross (Electrified)
  - Corolla Cross (Electrified)
  - ATIV (Electrified)
  - bZ4X (Electrified)
  - Camry (Electrified)
  - Zenix (Electrified)
  - Corolla Altis (Electrified)
  - Corolla Cross GR-S HEV (Gazoo Racing)
  - Corolla Altis GR-S (Gazoo Racing)
  - Hilux GR-S (Gazoo Racing)
  - Fortuner GR-S (Gazoo Racing)
9. Attitude Black Mica (2-Tone) ()
  - Fortuner (Crossovers & SUVs)
  
10. Sparkling Black Pearl Crystal Shine (#08112f)
  - Fortuner (Crossovers & SUVs)
  
11. Crystal Black Silica (#000000)
  - GR 86

12. Precious Black (#000000)
  - GR Yaris (Gazoo Racing)
 
### Blue

1. Celestial Blue (#023087)
  - Urban Cruiser BEV (Crossovers & SUVs)
  - Urban Cruiser BEV (Electrified)
  
2. Grayish Blue Mica Metallic (#263243)
  - Vios (Hatchbacks & Sedans)

3. Dark Blue Mica (#0e1538)
  - bZ4X (Crossovers & SUVs)
  - RAV4 (Crossovers & SUVs)
  - Hilux (Vans & pick-ups)
  - bZ4X (Electrified)
  - RAV4 (Electrified)
  - Hilux GR-S (Gazoo Racing)
  
4. Sapphire Blue Pearl (#000048)
  - GR 86 (Gazoo Racing)
  
5. Dawn Blue Metallic (#001b60)
  - GR Supra (Gazoo Racing)

### Bronze

1. Avant-Garde Bronze Metallic (#e8e1e1)
  - RAV4 (Crossovers & SUVs)
  - Land Cruiser Prado (Crossovers & SUVs)
  - RAV4 (Electrified)
  
2. Oxide Bronze Metallic (#51524d)
  - Hilux (Vans & pick-ups)
  - Hilux GR-S (Gazoo Racing)
 
### Gray

1. Gray Metallic (#515151)
  - Wigo (Hatchbacks & Sedans)
  - ATIV (Hatchbacks & Sedans)
  - Raize (Crossovers & SUVs)
  - Fortuner (Crossovers & SUVs)
  - Land Cruiser (Crossovers & SUVs)
  - Zenix (MPVs)
  - Hilux (Vans & pick-ups)
  - ATIV (Electrified)
  - Zenix (Electrified)
  - Hilux GR-S (Gazoo Racing)
  
2. Cement Gray Metallic (#8c9093)
  - Corolla Cross (Crossovers & SUVs)
  - Corolla Cross (Electrified)
  - Corolla Cross GR-S HEV (Gazoo Racing)
  
3. Urban Rock (#bbbbbd)
  - RAV4 (Crossovers & SUVs)
  - RAV4 (Electrified)
  
4. Matte Storm Gray Metallic (#505d6d)
  - GR Supra (Gazoo Racing)
 
5. Magnetite Gray Metallic (#2b2b2b)
  - GR 86 (Gazoo Racing)

6. Volcanic Ash Gray Metallic (#3a4557)
  - GR Supra (Gazoo Racing)

7. Metal Stream Metallic (#7d7f8b)
  - ATIV (Hatchbacks & Sedans)
  - Corolla Altis (Hatchbacks & Sedans)
  - Corolla Cross (Crossovers & SUVs)
  - Corolla Cross (Electrified)
  - ATIV (Electrified)
  - Corolla Altis (Electrified)
  - Corolla Cross GR-S HEV (Gazoo Racing)
  - Corolla Altis GR-S (Gazoo Racing)
  
8. Precious Metal (#515560)
  - Camry (Hatchbacks & Sedans)
  - bZ4X (Crossovers & SUVs)
  - Alphard (Vans & pick-ups)
  - bZ4X (Electrified)
  - Camry (Electrified)
  - Alphard (Electrified)
  - GR Corolla (Gazoo Racing)
  - GR Yaris (Gazoo Racing)
  
9. Grandeur Grey (#7a7a7c)
  - Urban Cruiser BEV (Crossovers & SUVs)
  - Urban Cruiser BEV (Electrified)
  
10. Massive Gray (#767d8a)
  - RAV4 (Crossovers & SUVs)
  - RAV4 (Electrified)
  
### Green

1. Land Breeze Green (#35371e)
  - Urban Cruiser BEV (Crossovers & SUVs)
  - Urban Cruiser BEV (Electrified)
  
2. Greenish Gun Metal (#206c58)
  - Yaris Cross (Hatchbacks & Sedans)
  - Yaris Cross (Electrified)
  
3. Greenish Gun Metal Mica Metallic (#4e5b4f)
  - Avanza (MPVs)
 
4. Ever Rest (#3b4e4f)
  - RAV4 (Crossovers & SUVs)
  - RAV4 (Electrified)

5. Moss Green (#112c23)
  - GR 86 (Gazoo Racing)
  
### Jade

1. Alumina Jade Metallic (#627564)
  - Vios (Hatchbacks & Sedans)
  - Innova (MPVs)

### Orange

1. Orange Metallic 3 (#932200)
  - Wigo (Hatchbacks & Sedans)

2. Plasma Orange (#ed4b24) 
  - GR Supra (Gazoo Racing)

### Red

1. Red 2 (#b40208)
  - Raize (Crossovers & SUVs)

2. Red Mica (#800000)
  - RAV4 (Crossovers & SUVs)
  - RAV4 (Electrified)
  
3. Red Mica Metallic (#920002)
  - Corolla Altis (Hatchbacks & Sedans)
  - Innova (MPVs)
  - Corolla Altis (Electrified)
  - Corolla Altis GR-S (Gazoo Racing)
  
  
4. Red Mica Metallic 2 (#7c0000)
  - Wigo (Hatchbacks & Sedans)

5. Super Red V (#d6353c) 
  - Vios (Hatchbacks & Sedans)

6. Emotional Red (#770000)
  - Corolla Cross (Crossovers & SUVs)
  - bZ4X (Crossovers & SUVs)
  - Hilux (Vans & pick-ups)
  - Corolla Cross (Electrified)
  - bZ4X (Electrified)
  - GR Corolla (Gazoo Racing)
  - GR Yaris (Gazoo Racing)
  - Corolla Cross GR-S HEV (Gazoo Racing)
  - Hilux GR-S (Gazoo Racing)
  
7. Ignition Red (#a20000)
  - GR 86 (Gazoo Racing)
  
8. Prominence Red (#d32944)
  - GR Supra (Gazoo Racing)

9. Dark Red Mica Metallic (#bb2f34)
  - Veloz (Crossovers & SUVs)
  - Rush (Crossovers & SUVs)
  - Avanza (MPVs)
  - Rush GR-S (Gazoo Racing)
  
10. Blackish Red Mica (#5d313a)
  - Vios (Hatchbacks & Sedans)
  - Innova (MPVs)

### Scarlet

1. Scarlet SE (#770000)
  - ATIV (Hatchbacks & Sedans)
  - Yaris Cross (Hatchbacks & Sedans)
  - Yaris Cross (Electrified)
  - ATIV (Electrified)
  
### Silver

1. Silver Metallic (#bfbfbf)
  - Fortuner (Crossovers & SUVs)
  - Zenix (MPVs)
  - Hilux (Vans & pick-ups)
  - Zenix (Electrified)
  - Hilux GR-S (Gazoo Racing)
  
2. Silver Metallic 1 (#cdd5d8)
  - Vios (Hatchbacks & Sedans)
  - Innova (MPVs)
  - Tamaraw (Utility Vehicles)
  
3. Silver Metallic 2 (#bfbfbf)
  - Land Cruiser (Crossovers & SUVs)
  - Super Grandia (Vans & Pick-ups)
  
4. Silver Metallic 4 (#bfbfbf)
  - Wigo (Hatchbacks & Sedans)
  - Raize (Crossovers & SUVs)
  - Avanza (MPVs)

5. Silver Mica Metallic (#d6d6d6)
  - Hiace (Vans & Pick-ups)
  - Commuter Deluxe (Vans & Pick-ups)
  - GL Grandia (Vans & Pick-ups)
  - Grandia Tourer (Vans & Pick-ups)
  
6. Ice Silver Metallic (#8d99a7)
  - GR 86 (Gazoo Racing)
  
7. Splendid Silver (#f0f0f0)
  - Urban Cruiser BEV (Crossovers & SUVs)
  - Urban Cruiser BEV (Electrified)
  
8. Purplish Silver Mica Metallic (#5a5a63)
  - Veloz (Crossovers & SUVs)
  
### Turquoise

1. Turquoise Mica Metallic (#034f75)
  - Raize (Crossovers & SUVs)

2. Dark Turquoise SE (#1e345b)
  - Yaris Cross (Hatchbacks & Sedans)
  - Yaris Cross (Electrified)
  
### White

1. White 1 (#ffffff)
  - Hiace (Vans & Pick-ups)
  - Commuter Deluxe (Vans & Pick-ups)
  - Coaster (Vans & Pick-ups)
  
2. White 2 (#ffffff)
  - Wigo (Hatchbacks & Sedans)
  - Rush (Crossovers & SUVs)
  - Avanza (MPVs)
  - Tamaraw (Utility Vehicles)
  - Lite ACE (Utility Vehicles)
  - Rush GR-S (Gazoo Racing)
  
3. White Metallic (#ffffff)
  - GR Supra (Gazoo Racing)
  
4. Super White II (#ffffff)
  - Vios (Hatchbacks & Sedans)
  - Corolla Altis (Hatchbacks & Sedans)
  - RAV4 (Crossovers & SUVs)
  - Innova (MPVs)
  - Hilux (Vans & pick-ups)
  - Hilux Fleet (Vans & pick-ups)
  - Tamaraw (Utility Vehicles)
  - RAV4 (Electrified)
  - Corolla Altis (Electrified)
  - GR Corolla (Gazoo Racing)
  - GR Yaris (Gazoo Racing)
  - Corolla Altis GR-S (Gazoo Racing)
  - Hilux GR-S (Gazoo Racing)
  
5. White Pearl Mica (#ffffff)
  - Land Cruiser Prado (Crossovers & SUVs)
  
6. White Pearl Crystal Shine (#ffffff)
  - Yaris Cross (Hatchbacks & Sedans)
  - Innova (MPVs)
  - Super Grandia (Vans & Pick-ups)
  - Yaris Cross (Electrified)
  
7. Platinum White Pearl Mica (#f8f9fa)
  - ATIV (Hatchbacks & Sedans)
  - Camry (Hatchbacks & Sedans)
  - Corolla Altis (Hatchbacks & Sedans)
  - Veloz (Crossovers & SUVs)
  - Corolla Cross (Crossovers & SUVs)
  - bZ4X (Crossovers & SUVs)
  - RAV4 (Crossovers & SUVs)
  - Fortuner (Crossovers & SUVs)
  - Zenix (MPVs)
  - Alphard (Vans & pick-ups)
  - Corolla Cross (Electrified)
  - Corolla Cross (Electrified)
  - ATIV (Electrified)
  - bZ4X (Electrified)
  - RAV4 (Electrified)
  - Camry (Electrified)
  - Zenix (Electrified)
  - Corolla Altis (Electrified)
  - Alphard (Electrified)
  - Corolla Cross GR-S HEV (Gazoo Racing)
  - Corolla Altis GR-S (Gazoo Racing)
  - Fortuner GR-S (Gazoo Racing)
  
8. Arctic White (#ffffff)
  - Urban Cruiser BEV (Crossovers & SUVs)
  - Urban Cruiser BEV (Electrified)
  
9. Matte Avalanche White Metallic (#c0c4c3)
  - GR Supra (Gazoo Racing)
 
10. White Pearl SE (#ffffff)
  - Raize (Crossovers & SUVs)

11. Crystal White Pearl (#ffffff)
  - GR 86 (Gazoo Racing)
  
12. Precious White Pearl (#ffffff)
  - Land Cruiser (Crossovers & SUVs)

13. Luxury Pearl Toning (#e7e7e7)
  - Super Grandia (Vans & Pick-ups)
  - GL Grandia (Vans & Pick-ups)
  - Grandia Tourer (Vans & Pick-ups)
 
### Yellow

1. Yellow SE (#fdbb4d)
  - Wigo (Hatchbacks & Sedans)
  - Raize (Crossovers & SUVs)


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