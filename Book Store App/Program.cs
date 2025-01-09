using Book_Store_App.Models.Domain;
using Book_Store_App.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataBaseContext>(options =>
            
                options.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
            );
            builder.Services.AddScoped<IGenreServices, GenreServices>();
            builder.Services.AddScoped<IAuthorServices, AuthorServices>();
            builder.Services.AddScoped<IPublisher, PublisherServices>();
            builder.Services.AddScoped<IBookServices, BookServices>();



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
                pattern: "{controller=Genre}/{action=Add}/{id?}");

            app.Run();
        }
    }
}
