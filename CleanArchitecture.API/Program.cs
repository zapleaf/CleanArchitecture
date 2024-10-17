using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Infrastructure.Seeders;
using CleanArchitecture.Application.Extensions;

namespace CleanArchitecture.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // You could get connection string from appsetting and pass it for DbContext or 
            // as in this case, pass the entire config to our Infrastructure service
            builder.Services.AddInfrastructure(builder.Configuration);     // Goes to the AddInfrastructure method in ServiceCollectionExtension class
            builder.Services.AddApplication();                             // Goes to the AddApplication method in ServiceCollectionExtension class

            var app = builder.Build();
            
            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IAppSeeder>();
            await seeder.Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
