using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

public class Startup {
  public void ConfigureServices(IServiceCollection services) {
    //services.AddRazorPages();
    services.AddControllers();
  }

  public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }

    app.UseRouting();
    app.UseDefaultFiles();
    app.UseStaticFiles();

      app.UseEndpoints(endpoints =>
        {
      //    endpoints.MapRazorPages();

          endpoints.MapGet("/", async context =>
            {
              await context.Response.WriteAsync("Hello World!");
//            await context.Response.WriteAsync("index.html");
            });
        });
    }
  }
