using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YoutubeClone.Foundation;
using YoutubeClone.Foundation.MappingProfile;
using YoutubeClone.Membership;
using YoutubeClone.Membership.Entities;
using YoutubeClone.Membership.Extensions;
using YoutubeClone.Membership.Seed;

namespace YoutubeClone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>()
           .AddRoles<Role>()
           .AddHibernateStores();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FoundationProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // This will all go in the ROOT CONTAINER and is NOT TENANT SPECIFIC.
            builder.RegisterModule(new WebModule());
            builder.RegisterModule(new MembershipModule());
            builder.RegisterModule(new FoundationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IUserDataSeed userDataSeed)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseDatabaseErrorPage();
            }
            else
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


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            userDataSeed.SeedUserAsync().Wait();
        }
    }
}
