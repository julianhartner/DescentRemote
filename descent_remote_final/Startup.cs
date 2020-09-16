using descent_remote_final.Models;
using descent_remote_final.Models.Lieutenants;
using descent_remote_final.Models.Monsters;
using descent_remote_final.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace descent_remote_final
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
            services.AddControllersWithViews();
            services.AddScoped<UserService>();
            services.AddScoped<SkillCardService>();
            services.AddScoped<ShopCardService>();
            services.AddScoped<ClassEquipmentCardService>();
            services.AddScoped<FamiliarCardService>();
            services.AddScoped<LieutenantService>();
            services.AddScoped<MonsterService>();
            services.AddSingleton<GameHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GameHandler gameHandler, UserService userService, LieutenantService lieutenantService, MonsterService monsterService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Load users
            IList<User> userList = userService.Get();

            foreach (var user in userList)
            {
                user.Lieutenants = new List<Lieutenant>();
                user.Monsters = new List<Monster>();
                user.Character.CurrentHealth = 0;
                user.Character.CurrentStamina = 0;
                user.Character.HeroicFeatUsed = false;
            }

            gameHandler.Users = userList;

            IList<Lieutenant> lieutenants = lieutenantService.Get();
            IList<Monster> monsters = monsterService.Get();

            gameHandler.Lieutenants = lieutenants;
            gameHandler.Monsters = monsters;
        }
    }
}
