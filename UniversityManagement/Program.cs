using BLL.Services;
using DAL.Data;
using DAL.Repositories.Implimentation;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Controllers;

namespace UniversityManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Repository & Services
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<CourseServices>();
            builder.Services.AddScoped<ICourseAssingmentRepository, CourseAssignmentRepository>();
            builder.Services.AddScoped<CourseAssignmentServices>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<DepartmentServices>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<EnrollmentServices>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<InstructorServices>();
            builder.Services.AddScoped<IOfficeAssignmentRepository, OfficeAssignmentRepository>();
            builder.Services.AddScoped<OfficeAssignmentServices>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<StudentServices>();


            // Controllers
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DB Context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

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
