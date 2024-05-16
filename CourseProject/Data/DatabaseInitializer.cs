using Microsoft.EntityFrameworkCore;

namespace CourseProject.Data
{
    public static class DatabaseInitializer
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>()?.Database.Migrate();
            }
        }
    }
}
