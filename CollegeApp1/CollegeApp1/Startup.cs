using CollegeApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp1
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("CollegeDbConnection")));
            services.AddControllersWithViews();
        }
    }
}
