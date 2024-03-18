using System;
using System.Text.Json;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using modpack.DTO;
using modpack.Models;
using modpack.ViewModels;

namespace modpack.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly ModPackContext _context;
        private readonly ILogger<AdminUserController> _logger;
        private IWebHostEnvironment _environment;

        public AdminUserController(ModPackContext context, ILogger<AdminUserController> logger, IWebHostEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_ADMIN))
            {
                string adminUser = HttpContext.Session.GetString(CDictionary.SK_LOGINED_ADMIN);
                Administrator admin = JsonSerializer.Deserialize<Administrator>(adminUser);
                int AdminID = admin.AdministratorId;

                var aVM = _context.Administrators
                     .Where(a => a.AdministratorId == AdminID)
                     .Select(a => new CAdminViewModel
                     {
                         AdminID = a.AdministratorId,
                         AdminTitleID = a.TitleId,
                         TitleName = a.Title.Name,
                         AdminName = a.Name,
                         aAdminCode = a.AdminCode,
                         AdminImage = a.Image,
                         AdminAccount = a.Account,
                         AdminPassword = a.Password,
                     })
                     .FirstOrDefault();
                return View(aVM);
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Login()
        {
            ViewData["Layout"] = null;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CLoginViewModel vm)
        {
            if (vm.txtAccount != null && vm.txtPassword != null)
            {
                Administrator adminUser = _context.Administrators.FirstOrDefault(
                    t => t.Account.Trim().Equals(vm.txtAccount.Trim()) &&
                        t.Password.Trim().Equals(vm.txtPassword.Trim()));
               
                if (adminUser != null)
                {// 查有此人 登入成功.
                    string json = JsonSerializer.Serialize(adminUser);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_ADMIN, json);
                    string script = $@"<script>alert('歡迎 {adminUser.Name} 登入');</script>";
                    TempData["Script"] = script;
                    ModelState.AddModelError("txtError", "登入成功");
                    return RedirectToAction("Index");
                }
                else
                {// 查無此人.
                    ModelState.AddModelError("txtError", "帳號或密碼不正確");
                    return View();
                }
            }
            else
            {// 輸入為空.
                ModelState.AddModelError("txtError", "帳號或密碼未輸入");
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove(CDictionary.SK_LOGINED_ADMIN);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            string adminUser = HttpContext.Session.GetString(CDictionary.SK_LOGINED_ADMIN);
            Administrator ad = JsonSerializer.Deserialize<Administrator>(adminUser);
            int AdminID = ad.AdministratorId;

            var am = await _context.Administrators.FindAsync(AdminID);
            if (am != null)
            {
                var titleName = _context.AdministratorTitles
                    .Where(at => at.TitleId == am.TitleId)
                    .Select(at => at.Name)
                    .FirstOrDefault();
                ViewData["TitleId"] = new SelectList(_context.AdministratorTitles, "TitleId", "Name", am.TitleId);

                var vm = new CAdminViewModel
                {
                    AdminID = am.AdministratorId,
                    AdminTitleID = am.TitleId,
                    //TitleName = am.Title.Name,
                    AdminName = am.Name,
                    aAdminCode = am.AdminCode,
                    AdminImage = am.Image,
                    AdminAccount = am.Account,
                    AdminPassword = am.Password,
                };
                return View(vm);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CAdminViewModel aVM)
        {
            string adminUser = HttpContext.Session.GetString(CDictionary.SK_LOGINED_ADMIN);
            Administrator admin = JsonSerializer.Deserialize<Administrator>(adminUser);
            int AdminID = admin.AdministratorId;

            Administrator aEdit = await _context.Administrators.FindAsync(AdminID);
            if (aEdit != null)
            {
                if (aVM.photo != null)
                {
                    //string photoName = Guid.NewGuid().ToString() + ".jpg";
                    string photoName = "adm" + Guid.NewGuid().ToString().Substring(0, 5) + ".png";
                    aEdit.Image = photoName;
                    using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, "images/admin", photoName), FileMode.Create))
                    {
                        await aVM.photo.CopyToAsync(fileStream);
                    }
                }
                aEdit.Name = aVM.AdminName;
                aEdit.TitleId = aVM.AdminTitleID;
                aEdit.Account = aVM.AdminAccount;
                aEdit.Password = aVM.AdminPassword;
                await _context.SaveChangesAsync();
            }

            ViewData["TitleId"] = new SelectList(_context.AdministratorTitles, "TitleId", "Name", aVM.AdminTitleID);
            return RedirectToAction("Index");
        }

        private bool AdministratorExists(int id)
        {
            return _context.Administrators.Any(e => e.AdministratorId == id);
        }

        // GET: AdminUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators
                .Include(a => a.Title)
                .FirstOrDefaultAsync(m => m.AdministratorId == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // GET: AdminUser/Create
        public IActionResult Create()
        {
            ViewData["TitleId"] = new SelectList(_context.AdministratorTitles, "TitleId", "Name");
            return View();
        }

        // POST: AdminUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdministratorId,TitleId,Name,Account,Password,Modifier,ModificationTime")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TitleId"] = new SelectList(_context.AdministratorTitles, "TitleId", "Name", administrator.TitleId);
            return View(administrator);
        }

        // GET: AdminUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators
                .Include(a => a.Title)
                .FirstOrDefaultAsync(m => m.AdministratorId == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // POST: AdminUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrator = await _context.Administrators.FindAsync(id);
            if (administrator != null)
            {
                _context.Administrators.Remove(administrator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
