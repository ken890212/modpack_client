using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using modpack.Models;
using modpack.ViewModels;
using System.Text.Json;
using X.PagedList;
using X.PagedList.Mvc;
using Humanizer;

namespace modpack.Controllers
{
    public class AdminEmployeeInfoController : Controller
    {
        private readonly ModPackContext _context;
        private IWebHostEnvironment _environment;

        public AdminEmployeeInfoController(ModPackContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: AdminEmployeeInfo
        public async Task<IActionResult> List(CKeywordViewModel vm, string searchStringTitle, string searchStringName, string sortOrder, int page = 1, int pageSize = 10)
        {
            string adminUser = HttpContext.Session.GetString(CDictionary.SK_LOGINED_ADMIN);
            Administrator admin = JsonSerializer.Deserialize<Administrator>(json: adminUser);
            int adminTitleId = admin.TitleId;

            List<CAdminViewModel> list = await _context.Administrators
               .Where(a => string.IsNullOrEmpty(vm.txtKeyWord) || a.Name.Contains(vm.txtKeyWord))
               .Where(a => a.TitleId == adminTitleId || a.Title.Permissions > _context.AdministratorTitles  // 移除  a.TitleId == adminTitleId || 沒有等於
                   .Where(at => at.TitleId == adminTitleId)
                   .Select(at => at.Permissions)
                   .FirstOrDefault())
               .Select(a => new CAdminViewModel
               {
                   AdminID = a.AdministratorId,
                   AdminTitleID = a.TitleId,
                   TitleName = a.Title.Name,
                   //aPermissions = a.Title.Permissions,
                   AdminName = a.Name,
                   aAdminCode = a.AdminCode,
                   AdminImage = a.Image,
                   AdminAccount = a.Account
               })
               .ToListAsync();

            //List<CAdminViewModel> list = await _context.Administrators
            //    .Where(a => string.IsNullOrEmpty(vm.txtKeyWord) || a.Name.Contains(vm.txtKeyWord))
            //    .Where(a => a.Title.Permissions < admin.Title.Permissions) // 筛选权限小于当前登录管理员的员工
            //    .Select(a => new CAdminViewModel
            //    {
            //        AdminID = a.AdministratorId,
            //        AdminTitleID = a.TitleId,
            //        TitleName = a.Title.Name,
            //        AdminName = a.Name,
            //        aAdminCode = a.AdminCode,
            //        AdminImage = a.Image,
            //        AdminAccount = a.Account
            //    })
            //    .ToListAsync();


            // 再添加当前登录管理员的信息到列表中
            CAdminViewModel currentAdmin = new CAdminViewModel
            {
                AdminID = admin.AdministratorId,
                AdminTitleID = admin.TitleId,

                //TitleName = admin.Title.Name,
                //Permissions = admin.Title.Permissions,
                AdminName = admin.Name,
                aAdminCode = admin.AdminCode,
                AdminImage = admin.Image,
                AdminAccount = admin.Account
            };
            list.Add(currentAdmin);

            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "AdminID";
            }

            switch (sortOrder)
            {
                case "aPermission_desc":
                    list = list.OrderByDescending(a => a.aPermissions).ToList();
                    break;
                case "aPermission_asc":
                    list = list.OrderBy(a => a.aPermissions).ToList();
                    break;
                case "aAdminCode_desc":
                    list = list.OrderByDescending(a => a.aAdminCode).ToList();
                    break;
                case "aAdminCode_asc":
                    list = list.OrderBy(a => a.aAdminCode).ToList();
                    break;
                default:
                    list = list.OrderBy(a => a.AdminID).ToList();
                    break;
            }

            HttpContext.Session.SetString(CDictionary.SK_LOGINED_ADMIN, JsonSerializer.Serialize(admin));
            var result = list.ToPagedList(page, pageSize);
            return View(result);
        }

        // GET: AdminEmployeeInfo/Create
        public async Task<IActionResult> Create()
        {
            var titles = await _context.AdministratorTitles.ToListAsync();
            var defaultIndex = 8;
            if (titles.Count > defaultIndex)
            {
                var defaultTitleId = titles[defaultIndex].TitleId;
                ViewData["TitleId"] = new SelectList(titles, "TitleId", "Name", defaultTitleId);
            }
            else
            {
                ViewData["TitleId"] = new SelectList(titles, "TitleId", "Name");
            }
            return View();
        }

        // POST: AdminEmployeeInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CAdminViewModel avm)
        {
            Administrator ad = new Administrator
            {
                Name = avm.AdminName,
                TitleId= avm.TitleID,
                AdminCode = avm.aAdminCode,
                Image = avm.AdminImage,
                Account = avm.AdminAccount,
                Password = avm.AdminPassword
            };

            _context.Add(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        // GET: AdminEmployeeInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Administrators
              .Include(a => a.Title)
              .FirstOrDefaultAsync(a => a.AdministratorId == id);

            if (ad == null)
            {
                return NotFound();
            }

            var viewModel = new CAdminViewModel
            {
                AdminID = ad.AdministratorId,
                AdminTitleID = ad.TitleId,
                AdminName = ad.Name,
                aAdminCode = ad.AdminCode,
                AdminImage = ad.Image,
                AdminAccount = ad.Account,
                AdminPassword = ad.Password
            };
            //var viewModel = new CAdminViewModel(ad, ad.Title);  // abbr.
            ViewData["TitleId"] = new SelectList(_context.AdministratorTitles, "TitleId", "Name", ad.TitleId);
            return View(viewModel);
        }

        // POST: AdminEmployeeInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CAdminViewModel aVM)
        {
            Administrator aEdit = await _context.Administrators.FindAsync(aVM.AdminID);
            if (aEdit != null)
            {
                if (aVM.photo != null)
                {
                    string photoName = "adm" + Guid.NewGuid().ToString().Substring(0, 5) + ".jpeg";
                    using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, "images/admin", photoName), FileMode.Create))
                    {
                        await aVM.photo.CopyToAsync(fileStream);
                    }
                    aEdit.Image = photoName;
                }
                aEdit.Name = aVM.AdminName;
                aEdit.AdminCode = aVM.aAdminCode;
                aEdit.TitleId = aVM.AdminTitleID;
                aEdit.Account = aVM.AdminAccount;
                aEdit.Password = aVM.AdminPassword;
                await _context.SaveChangesAsync();
            }
            HttpContext.Session.SetString(CDictionary.SK_LOGINED_ADMIN, JsonSerializer.Serialize(aEdit));
            ViewData["TitleId"] = new SelectList(_context.AdministratorTitles, "TitleId", "Name", aVM.AdminTitleID);
            return RedirectToAction("List");
        }

        // GET: AdminEmployeeInfo/Delete/5
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

        // POST: AdminEmployeeInfo/Delete/5
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
            return RedirectToAction(nameof(List));
        }

        private bool AdministratorExists(int id)
        {
            return _context.Administrators.Any(e => e.AdministratorId == id);
        }

        // GET: AdminEmployeeInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Administrators
                .Include(a => a.Title)
                .FirstOrDefaultAsync(m => m.AdministratorId == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }
    }
}
