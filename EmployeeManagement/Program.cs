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

// Create the database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();
        
        // This will ensure the database is created
        context.Database.EnsureCreated();
        
        // Log or display success message
        Console.WriteLine("Database checked and created if needed.");
    }
    catch (Exception ex)
    {
        // Log the error - this will help identify the issue
        Console.WriteLine($"An error occurred while ensuring the database exists: {ex.Message}");
    }
}

app.Run();
