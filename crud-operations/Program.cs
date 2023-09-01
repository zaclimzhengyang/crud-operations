using crud_operations.Data;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MvcDbContext>();

// MSSQL DB Conn
// string connString = builder.Configuration.GetConnectionString("MvcConnectionString");
// builder.Services.AddDbContextPool<MvcDbContext>(options =>
    // options.UseMySql(builder.Configuration.GetConnectionString("MvcConnectionString"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MvcConnectionString"))));

// builder.Services.AddTransient<MySqlConnection>(_ =>
//     new MySqlConnection(builder.Configuration.GetConnectionString("MvcConnectionString")));

//MySQL DB ConnDbContext
// string _GetConnStringName = builder.Configuration.GetConnectionString("DefaultConnectionMySQL");
// string _GetConnStringName = builder.Configuration.GetConnectionString("ConnectStrings:DefaultConnectionMySQL");
string connectionString = "Server=localhost;Port=3306;Database=TutorialDB;User=limzy;Password=password";


// builder.Services.AddDbContextPool<MvcDbContext>(options => options.UseMySql(_GetConnStringName, ServerVersion.AutoDetect(_GetConnStringName)));
builder.Services.AddDbContextPool<MvcDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllerRoute(
//         name: "employeeUpdate",
//         pattern: "Employees/Update/{id}",
//         defaults: new { controller = "Employees", action = "Update" });
//
//     endpoints.MapControllerRoute(
//         name: "default",
//         pattern: "{controller=Home}/{action=Index}/{id?}");
// });


app.Run();