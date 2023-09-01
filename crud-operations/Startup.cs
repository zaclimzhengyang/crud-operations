// using crud_operations.Data;
//
// namespace crud_operations;
//
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
//
// public class Startup
// {
//     private IConfiguration Configuration { get; }
//
//     public Startup(IConfiguration configuration)
//     {
//         Configuration = configuration;
//     }
//
//     public void ConfigureServices(IServiceCollection services)
//     {
//         // Other service configurations...
//
//         // Configure DbContext with the connection string from appsettings.json
//         services.AddDbContext<ApplicationDbContext>(options =>
//             options.UseMySql(Configuration.GetConnectionString("MvcConnectionString")));
//     }
//
//     // Other methods...
// }
