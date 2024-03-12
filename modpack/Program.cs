using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using modpack.Controllers;
using modpack.Data;
using modpack.Models;
using modpack.Service;

namespace modpack
{
    //github test
    public class Program
    {
        public static void Main(string[] args)
        {
            //§ì¨ú«e­±ºô§}
            string? xx = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build().GetSection("Kestrel").GetSection("Endpoints").GetSection("Http").GetSection("Url").Value;
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ModPackContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("modpack"));
            });

            string CorsPolicy = "AllowAny";
            builder.Services.AddCors(option =>
            {
                option.AddPolicy(name: CorsPolicy, policy =>
                {
                    policy.WithOrigins("*").WithHeaders("*").WithMethods("*");
                });
            });

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            // 自訂，註冊 session.
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(3);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // 自訂，註冊 cookie.
            builder.Services.AddAuthentication("YourAuthenticationScheme")
                .AddCookie("YourCookieAuthenticationScheme", options =>
                {
                    options.Cookie.Name = "YourCookieName"; // 設定Cookie的名稱
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // 設定Cookie的過期時間
                    options.LoginPath = "/Account/Login"; // 登入頁面的路徑
                    options.AccessDeniedPath = "/Account/AccessDenied"; // 拒絕訪問的路徑
                    options.SlidingExpiration = true; // 啟用滑動過期
                });
            // websocket
            builder.Services.AddSignalR();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();    // 需要?
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(CorsPolicy);
            app.UseHttpsRedirection();
            var provider = new FileExtensionContentTypeProvider();

            provider.Mappings[".data"] = "application/binary";

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });

            app.UseRouting();
            app.UseSession();   //. 啟用 session.
            app.UseAuthorization();     //. 啟用 cookie.
            app.UseWebSockets();    // 啟用 websocket


            app.MapControllers();
            app.MapControllerRoute(
                name: "Admin",
                pattern: "{controller=AdminUser}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.UseEndpoints(endpoints =>
            {//websocket
                endpoints.MapControllers();
                endpoints.MapHub<ImageCarouselHub>("/imageCarouselHub");
            });

            app.Run();
        }
    }
}
