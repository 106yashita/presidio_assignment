
using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Repositories;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region context
            builder.Services.AddDbContext<RequestTrackerContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
               );
            #endregion context

            #region repository
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            #endregion repository

            #region services
            builder.Services.AddScoped<IEmployeeService, EmployeeBasicService>();
            builder.Services.AddScoped<IUserService, UserService>();
            #endregion services

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
