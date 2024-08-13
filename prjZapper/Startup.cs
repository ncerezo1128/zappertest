using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.OpenApi.Models;
using prjZapper.Repository.Concretes;
using prjZapper.Repository.Contracts;

namespace prjZapper
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
            List<UserSettings> userSettings = new List<UserSettings>
            {
                new UserSettings { NumberSetting = 0, FunctionSetting = "SMS Notifications Enabled" },
                new UserSettings { NumberSetting = 1, FunctionSetting = "Push Notifications Enabled" },
                new UserSettings { NumberSetting = 2, FunctionSetting = "Bio-metrics Enabled" },
                new UserSettings { NumberSetting = 3, FunctionSetting = "Camera Enabled" },
                new UserSettings { NumberSetting = 4, FunctionSetting = "Location Enabled" },
                new UserSettings { NumberSetting = 5, FunctionSetting = "NFC Enabled" },
                new UserSettings { NumberSetting = 6, FunctionSetting = "Vouchers Enabled" },
                new UserSettings { NumberSetting = 7, FunctionSetting = "NFC Enabled" }

            };
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "prjZapper", Version = "v1" });
            });

            services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddSingleton(userSettings);
            services.AddSingleton<IInitListUserSettings, InitListUserSettings>();
            services.AddTransient<IUserSettingsFunction, UserSettingsFunction>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<ZapperSecurity>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shortcut v1"));
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

