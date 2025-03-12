using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get the connection string from configuration, or use a default if not found
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
                        "Server=(localdb)\\mssqllocaldb;Database=EmployeeManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true";

// Add DbContext configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Create and seed the database
using (var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();
        
        // Drop and recreate the database to ensure seed data is applied
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        Console.WriteLine("Database recreated and seeded successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while ensuring the database exists: {ex.Message}");
    }
}

app.Run();
