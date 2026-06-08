using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Data.Seeds;

var builder = WebApplication.CreateBuilder(args);

// ===================== DB Config =====================

// Data/ApplicationDbContext.cs
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// ===================== Authentication (Cookies) =====================

// Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login"; // Unauthorized users go here.
            options.AccessDeniedPath = "/Login";
        });



// ===================== MVC Setup =====================

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



// ===================== Seeding =====================

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Call the Seed() method for each seeeding class to populate the DB with initial data.
    UserSeed.Seed(context);
    ToyotaAdminSeed.Seed(context);

    VehicleTypeSeed.Seed(context); 
    VehicleModelSeed.Seed(context);
    VehicleColorCategorySeed.Seed(context);
    VehicleColorSeed.Seed(context);

    BatteryTypeSeed.Seed(context);
    PowerTrainSeed.Seed(context);
    FuelTypeSeed.Seed(context);
    TransmissionTypeSeed.Seed(context);

    FrontBrakeTypeSeed.Seed(context);
    RearBrakeTypeSeed.Seed(context);
    DriveModeSeed.Seed(context);
    PowerSteeringTypeSeed.Seed(context);
}



// ===================== Error handling (Production) =====================

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }



// ===================== Middleware Pipeline =====================

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS.
app.UseStaticFiles(); // Serves static files (CSS, JS, images, etc.).

app.UseRouting(); // Matches incoming requests to controllers.

app.UseAuthentication(); // Reads authentication cookie and sets HttpContext.User. W/o this, User.Identity.IsAuthenticated will ALWAYS be false
app.UseAuthorization(); // Checks permissions (e.g., [Authorize], roles, policies)




// ===================== Routing =====================

// Default route = homepage.
app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { area = "Public", controller = "Home", action = "Homepage"});


// Standard MVC route.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { area = "Public", controller = "Home", action = "Homepage" });

app.Run();