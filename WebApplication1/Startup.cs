using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using WebApplication1.Context;
using WebApplication1.Service.Courses;
using WebApplication1.Service.Groups;
using WebApplication1.Service.Students;
using WebApplication1.Service.Subjects;
using WebApplication1.Service.Teachers;

namespace WebApplication1
{
    public class Startup
    {
        string path = Directory.GetCurrentDirectory() + "\\DataBase";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbCtx>(option => option.UseSqlServer(Configuration.GetConnectionString("ConnectionString").Replace("[DataDirectory]", path)));
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Group}/{action=Index}/{id?}");
            });
        }
    }
}
