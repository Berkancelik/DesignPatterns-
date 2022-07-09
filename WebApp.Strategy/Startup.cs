using BaseProject.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Strategy.Models;
using WebApp.Strategy.Repositories;

namespace BaseProject.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // get service almaya çalýþtýðýmýz servis yok ise hata fýrlatmaz geriye null döner
            // ama required der isek geriye  hata fýrlatýr o servis yok ise
            services.AddScoped<IProductRepository>(sp =>
            {
                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();

                var claim = httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == Settings.claimDatabaseType).FirstOrDefault();

                var context = sp.GetRequiredService<Context>();
                if (claim == null) return new ProductRepositoryFromSqlServer(context);

                var databaseType = (EDatabaseType)int.Parse(claim.Value);

                return databaseType switch
                {
                    EDatabaseType.SqlServer => new ProductRepositoryFromSqlServer(context),
                    EDatabaseType.MongoDb => new ProductRepositoryFromMongoDb(Configuration),
                    _ => throw new NotImplementedException()
                };
            });





            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
