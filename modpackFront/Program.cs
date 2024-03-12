using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using modpackFront.Data;
using modpackFront.Models;
using Microsoft.AspNetCore.Authentication.Cookies; // 引入 Cookie 身份驗證的命名空間

namespace modpackFront
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //抓取前面網址
            // 初始化配置檔案讀取
            string? xx = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build().GetSection("Kestrel").GetSection("Endpoints").GetSection("Http").GetSection("Url").Value;
            var builder = WebApplication.CreateBuilder(args);

            // 配置資料庫上下文
            builder.Services.AddDbContext<ModPackContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("modpack"));
            });

            // 設定跨來源資源共享(CORS)政策
            string CorsPolicy = "AllowAny";
            builder.Services.AddCors(option =>
            {
                option.AddPolicy(name: CorsPolicy, policy =>
                {
                    policy.WithOrigins("*").WithHeaders("*").WithMethods("*");
                });
            });

            // 配置應用程式的資料庫上下文和例外頁面
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // 設定預設身份驗證方式為 Identity
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // 新增 Cookie 身份驗證服務
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Login"; // 指定登入路徑
                    options.LogoutPath = "/Login/Logout"; // 指定登出路徑
                    // 在此可以設定更多 Cookie 選項，例如過期時間等
                });

            // 新增 MVC 控制器與視圖的支持
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // 配置 HTTP 請求處理管道
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // 啟用 CORS
            app.UseCors(CorsPolicy);

            // 啟用 HTTPS 重定向
            app.UseHttpsRedirection();

            // 設定靜態檔案的內容類型
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".data"] = "application/binary";
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });

            // 配置路由
            app.UseRouting();

            // 啟用身份驗證
            app.UseAuthentication();
            // 啟用授權
            app.UseAuthorization();

            // 配置 MVC 路由
            app.MapControllers();
            app.MapControllerRoute(
                name: "Home",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            // 啟動應用程式
            app.Run();
        }
    }
}
