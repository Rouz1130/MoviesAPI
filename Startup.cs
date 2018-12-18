using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesAPI.Services;
namespace MoviesAPI
{
    public class Startup
     {
          public void ConfigureServices(IServiceCollection services)
{
     var connectionString = "Server=localhost;Database=MoviesDB;User Id=sa;Password=Passw0rd!";
     services.AddDbContext<MoviesDbContext>(o =>
          o.UseSqlServer(connectionString));
     services.AddMvc();
}
          public void Configure(IApplicationBuilder app,
               IHostingEnvironment env,
               MoviesDbContext moviesDbContext)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }
               app.UseStaticFiles();

               moviesDbContext.CreateSeedData();

               app.UseMvcWithDefaultRoute();

            //    app.Run(async (context) =>
            //    {
            //         await context
            //                .Response
            //                .WriteAsync("Hello World!");
            //    });
          }
     }
}