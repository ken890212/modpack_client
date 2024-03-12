using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using modpack.Models;
using modpack.ViewModels;
using X.PagedList;
using Microsoft.AspNetCore.SignalR;


namespace modpack.Controllers
{
    public class AdminServiceRecordsController : Controller
    {
        private readonly ModPackContext _context;
        private IWebHostEnvironment _environment;
        

        public AdminServiceRecordsController(ModPackContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
          
        }

        // GET: ServiceRecords
        public async Task<IActionResult> List(int page = 1, int pageSize = 10)
        {
            List<CServiceRecordsViewModel> sVM = await _context.ServiceRecords
                .Select(record => new CServiceRecordsViewModel
                {
                    aRecordID = record.RecordId,
                    aMemberID = record.MemberId,
                    aMemberName = record.Member.Name,
                    aQuestionContent = record.Question,
                    aQuestionTime = record.QuestionTime,
                    aAdminCode = record.AdministratorId,
                    aAdminName = record.Administrator.Name,
                    aAnswerContent = record.Answer,
                    aAnswerTime = record.AnswerTime,
                    aIsResolved = record.IsResolved,
                })
                .ToListAsync();

            var pagedResult = await sVM.ToPagedListAsync(page, pageSize);
            return View(pagedResult);
        }

        // GET: ServiceRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var serviceRecord = await _context.ServiceRecords
                .Include(s => s.Administrator)
                .Include(s => s.Member)
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (serviceRecord == null)
            {
                return NotFound();
            }
            return View(serviceRecord);
        }

        // GET: ServiceRecords/Create
        public IActionResult Create()
        {
            ViewData["AdministratorId"] = new SelectList(_context.Administrators, "AdministratorId", "Account");
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
            return View();
        }

        // POST: ServiceRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordId,MemberId,Question,QuestionTime,AdministratorId,Answer,AnswerTime,IsResolved")] ServiceRecord serviceRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministratorId"] = new SelectList(_context.Administrators, "AdministratorId", "Account", serviceRecord.AdministratorId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", serviceRecord.MemberId);
            return View(serviceRecord);
        }

        // GET: ServiceRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);
            if (serviceRecord == null)
            {
                return NotFound();
            }
            ViewData["AdministratorId"] = new SelectList(_context.Administrators, "AdministratorId", "Account", serviceRecord.AdministratorId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", serviceRecord.MemberId);
            return View(serviceRecord);
        }

        // POST: ServiceRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordId,MemberId,Question,QuestionTime,AdministratorId,Answer,AnswerTime,IsResolved")] ServiceRecord serviceRecord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceRecordExists(serviceRecord.RecordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            ViewData["AdministratorId"] = new SelectList(_context.Administrators, "AdministratorId", "Account", serviceRecord.AdministratorId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", serviceRecord.MemberId);
            return View(serviceRecord);
        }




		public async Task<IActionResult> ReplyTwo(int id)
        {// use SignalR.
            // 获取当前管理员的信息
            //int? currentAdminID = HttpContext.Session.GetInt32(CDictionary.SK_LOGINED_ADMIN);
            string currentAdmin = HttpContext.Session.GetString(CDictionary.SK_LOGINED_ADMIN);
            Administrator admin = JsonSerializer.Deserialize<Administrator>(currentAdmin);
            string currentAdminCode = admin.AdminCode;
            string currentAdminName = admin.Name;

            //if (currentAdminId == null)
            //{
            //    // 如果管理员ID不存在于会话中，可能需要执行一些逻辑，比如重定向到登录页面
            //    return RedirectToAction("Login", "AdminUser"); // 假设登录页面是 AdminUser 控制器的 Login 方法
            //}

            // 查询数据库获取所有会员的信息
            var serviceRecords = await _context.ServiceRecords

                .Where(sr => sr.MemberId == id)
                .Select(sr => new CServiceRecordsViewModel
                {
                    aRecordID = sr.RecordId,
                    aMemberID = sr.MemberId,
                    aMemberName = sr.Member.Name,
                    aQuestionContent = sr.Question,
                    aQuestionTime = sr.QuestionTime,
                    aAdminCode = sr.AdministratorId,
                    aAdminName = sr.Administrator.Name,
                    aAnswerContent = sr.Answer,
                    aAnswerTime = sr.AnswerTime,
                    aIsResolved = sr.IsResolved,
                    //CurrentAdminID = currentAdminID   // 若要改使用 viewmodel 方法
                })
                .ToListAsync();

            // 将当前管理员ID存储到ViewBag中
            ViewData["CurrentAdminCode"] = currentAdminCode;
            ViewData["CurrentAdminName"] = currentAdminName;
            ViewData["CurrentMemberId"] = id;
            ViewData["CurrentMemberName"] = serviceRecords.FirstOrDefault()?.aMemberName;

            return View(serviceRecords);
        }

        //[HttpPost]
        //public async Task<IActionResult> ReplyTwo(int currentAdminID, string answerContent, string answerTime)
        //{
        //    // 创建新的服务记录对象并保存到数据库中
        //    if (!string.IsNullOrEmpty(answerContent))
        //    {
        //        var admin = await _context.Administrators.FindAsync(currentAdminID);
        //        var newRecord = new ServiceRecord
        //        {
        //            AdministratorId = currentAdminID,
        //            Answer = answerContent,
        //            AnswerTime = DateTime.Parse(answerTime), // 根据需要解析时间
        //            IsResolved = true // 根据您的逻辑设置是否已解决
        //        };

        //        _context.ServiceRecords.Add(newRecord);
        //        await _context.SaveChangesAsync();

        //        // SignalR: Send message to clients
        //        //await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"{admin.Name} answered: {answerContent}");
        //    }

        //    return RedirectToAction("Reply");
        //}

        // GET: ServiceRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRecord = await _context.ServiceRecords
                .Include(s => s.Administrator)
                .Include(s => s.Member)
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (serviceRecord == null)
            {
                return NotFound();
            }

            return View(serviceRecord);
        }

        // POST: ServiceRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);
            if (serviceRecord != null)
            {
                _context.ServiceRecords.Remove(serviceRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool ServiceRecordExists(int id)
        {
            return _context.ServiceRecords.Any(e => e.RecordId == id);
        }
    }
}
