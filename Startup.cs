using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blog.Data.Interfaces;
using Blog.Data.Models;
using Blog.Data.Repository;
using Microsoft.AspNetCore.Identity;

namespace Blog
{
    public class Startup
    {
        private IConfigurationRoot _configurationString;
        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            _configurationString = new ConfigurationBuilder().SetBasePath(webHostEnvironment.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationString.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(
                opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 5;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Lockout.MaxFailedAccessAttempts = 5; 
                    opt.User.RequireUniqueEmail = true;
                    opt.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<IArticles, ArticleRepository>();
            services.AddTransient<ICategories, CategoryRepository>();
            services.AddTransient<ITags, TagRepository>();
            services.AddTransient<IDates, DateRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbObjects.Initial(context);
            }
        }
    }
}
