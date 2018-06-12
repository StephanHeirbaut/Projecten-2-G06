using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DotNet_GoeBezig_G11.Data;
using DotNet_GoeBezig_G11.Data.Repositories;
using DotNet_GoeBezig_G11.Filters;
using DotNet_GoeBezig_G11.Models;
using DotNet_GoeBezig_G11.Services;
using DotNet_GoeBezig_G11.Models.Domein;
using DotNet_GoeBezig_G11.Models.Domein.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Sakura.AspNetCore;
using Sakura.AspNetCore.Mvc;

namespace DotNet_GoeBezig_G11
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<CursistFilter>();
            services.AddScoped<ApplicationDataInitializer>();
            services.AddScoped<IGroepRepository, GroepRepository>();
            services.AddScoped<ICursistRepository, CursistRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IOrganisatieRepository, OrganisatieRepository>();
            services.AddScoped<IMotivatieRepository, MotivatieRepository>();
            services.AddScoped<IActieRepository, ActieRepository>();
            services.AddScoped<IActieContainerRepository, ActieContainerRepository>();
            services.AddScoped<IBerichtRepository, BerichtRepository>();
            services.AddScoped<ITaakRepository, TaakRepository>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddSingleton<IAuthorizationHandler, GroepNodigAuthorization>();
            services.AddAuthorization(options =>
                options.AddPolicy("GroepNodig", policy => policy.Requirements.Add(new GroepNodigRequirement())));

            services.AddMvc();
            services.AddBootstrapPagerGenerator(options =>
            {
                // Use default pager options.
                options.ConfigureDefault();
            });
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDataInitializer dataInitializer)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();
            app.UseStatusCodePagesWithRedirects("~/BeherenGroep/Index");

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=BeherenGroep}/{action=Index}/{id?}/{id2?}");
            });
       //  dataInitializer.InitializeData().Wait();
        }
    }
}
