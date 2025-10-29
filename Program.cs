using DapperASPNetCore.Repository;
using DapperASPNetCore.Context;
using DapperASPNetCore.Contracts;
using DapperASPNetCore.Entities;


public class Program {
  public static void Main(string[] args) {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSingleton<DapperContext>();
    builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
    builder.Services.AddControllers();
    builder.Services.AddRazorPages();

    var app = builder.Build();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.UseRouting();
    app.UseDefaultFiles();
    app.UseStaticFiles();



    app.UseEndpoints(endpoints =>
      {
        endpoints.MapRazorPages();
        //endpoints.MapGet("/services", async context =>
        //  {
        //  await context.Response.WriteAsync("index.html");
        //  });
          
      });

    app.Run();
  }
  
  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args).
      ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
          webBuilder.UseKestrel(options =>
          {
            options.ListenLocalhost(5000);
            options.ListenAnyIP(5001, listenOptions =>
            {
              listenOptions.UseHttps();
            });
          });
        });

}
