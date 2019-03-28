using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace ANightsTaleUI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<AbilityRepository>();
			services.AddScoped<CampaignRepository>();
			services.AddScoped<CharacterRepository>();
			services.AddScoped<ItemRepository>();
            services.AddScoped<UserRepository>();
			services.AddDbContext<ANightsTaleContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("ProjectDB")));

			services.AddSingleton<RngProvider>();

            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AuthDB")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // we could just use defaults and not set anything on options
                options.Password.RequiredLength = 12;
                options.Password.RequireNonAlphanumeric = true;
                // many options here
            })
                .AddEntityFrameworkStores<AuthDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "CharacterServiceAuth";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = context =>
                    {
                        // prevent redirect, just return unauthorized
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.Headers.Remove("Location");
                        // we use Task.FromResult when we're in an async context
                        // but there's nothing to await.
                        return Task.FromResult(0);
                    },
                    OnRedirectToAccessDenied = context =>
                    {
                        // prevent redirect, just return forbidden
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.Headers.Remove("Location");
                        // we use Task.FromResult when we're in an async context
                        // but there's nothing to await.
                        return Task.FromResult(0);
                    }
                };
            });

            services.AddAuthentication();

            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
#pragma warning disable CS0618 // Type or member is obsolete
			loggerFactory.AddConsole();
#pragma warning restore CS0618 // Type or member is obsolete

			//start logging to the console
#pragma warning disable CS0618 // Type or member is obsolete
			var logger = loggerFactory.CreateLogger<ConsoleLogger>();
#pragma warning restore CS0618 // Type or member is obsolete
			logger.LogInformation("Executing Configure()");
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

            app.UseAuthentication();

            app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
