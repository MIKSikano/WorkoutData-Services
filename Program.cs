using Microsoft.EntityFrameworkCore;
using WorkoutApplicationServices.Interfaces;
using WorkoutApplicationServices.Services;
using WorkoutApplicationServices.Data;
using System.Text.Json.Serialization;

namespace WorkoutApplicationServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            // bootstraps the neccessary dependencies

            // Add services to the container.

            var corConfigName = "CORS-Config";
            builder.Services.AddCors(options => {
                options.AddPolicy(name: corConfigName, policy => {
                    policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();

                });
            });

        
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
            });
            //configuration of data context
            //put parameters

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IWorkoutDataService, WorkoutDataMSSQLService>();
            builder.Services.AddScoped<IExerciseTypeService, ExerciseTypeMSSQLService>();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(corConfigName);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}


