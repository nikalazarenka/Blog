using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blog.Data.Interfaces;
using Blog.Data.Models;
using Blog.Data.Repository;

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

            services.AddTransient<IAllArticle, ArticleRepository>();
            services.AddTransient<IAllPublications, PublicationRepository>();
            services.AddTransient<IArticleCategory, CategoryRepository>();
            services.AddTransient<IArticleTags, TagRepository>();

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
            app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //DbObjects.Initial(context);
            }
        }
    }
}
