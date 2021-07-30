using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebProject.Data;
using Microsoft.EntityFrameworkCore;
using DataModel.Models;
using WebProject.Interfaces;
using WebProject.Services;
using WebProject.Areas.Admin.Interfaces;
using WebProject.Areas.Admin.Services;
using WebProject.Areas.User.Interfaces;
using WebProject.Areas.User.Services;

namespace WebProject {
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
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));

            services.AddRazorPages();

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<DatabaseContext>();
            services.AddMvc();

            // For client side
            services.AddTransient<ISignup, SignupServices>();
            services.AddTransient<ILogin, LoginService>();
            services.AddTransient<ILogout, LogoutService>();
            //services.AddTransient<IPoll, PollService>();

            // For admin area
            services.AddTransient<IAdminLogin, AdminLoginService>();
            services.AddTransient<IAdminLogout, AdminLogoutService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISettings, SettingsService>();

            // For profile area
            services.AddTransient<IProfileSettings, ProfileSettingsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
