using PatientsRegistration.Repository;
using PatientsRegistration.Service;

namespace PatientsRegistration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Add ConnectionString
            var connectionString = builder.Configuration.GetConnectionString("MVCConnectionString");

            //2 - Register Repository and Service as Middleware
            builder.Services.AddScoped<IPatientRepository, PatientRepositoryImpl>();
            builder.Services.AddScoped<IPatientService, PatientServiceImpl>();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Patient}/{action=Create}/{id?}");

            app.Run();
        }
    }
}


