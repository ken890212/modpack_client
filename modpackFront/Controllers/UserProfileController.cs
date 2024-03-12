using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using modpackFront.Data;
using modpackFront.Models;
using modpackFront.DTO;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace modpackFront.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly ModPackContext _context;

        public UserProfileController(ModPackContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Profile()
        {
            // 使用ClaimTypes.Name來獲取MemberId
            var memberIdString = User.FindFirst(ClaimTypes.Sid)?.Value; 
            if (!int.TryParse(memberIdString, out int memberId))
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.Level)
                .FirstOrDefaultAsync(m => m.MemberId == memberId);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }


        // 編輯功能
        public async Task<IActionResult> Edit()
        {

            var memberIdString = User.FindFirst(ClaimTypes.Sid)?.Value;
            if (!int.TryParse(memberIdString, out int memberId))
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.Level)
                .Where(m => m.MemberId == memberId).FirstOrDefaultAsync();

            if (member == null)
            {
                return NotFound();
            }

            var memberDto = new MemberDTO
            {
                id = member.MemberId,
                //Account = member.Account,
                //Password = member.Password,
                Name = member.Name,
                Address = member.Address,
                Phone = member.Phone,
                Email = member.Email,
                LevelName = member.Level.Name,
                ModificationTime = member.ModificationTime,
            };

            return View(memberDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MemberDTO memberDto)
        {
            if (memberDto == null)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == memberDto.id);
            if (member == null)
            {
                return NotFound();
            }

            // 更新 member 實體的屬性
            member.MemberId = memberDto.id;
            member.Name = memberDto.Name;
            member.Address = memberDto.Address;
            member.Phone = memberDto.Phone;
            member.Email = memberDto.Email;
            member.ModificationTime = DateTime.Now;
            // 根據需要更新其他屬性

            try
            {
                _context.Update(member);
                await _context.SaveChangesAsync();
                var userName = memberDto.Name;

                // 從現有的HttpContext.User中創建一個新的ClaimsIdentity
                var claimsIdentity = new ClaimsIdentity(User.Identity);

                // 移除舊的Name Claim
                var existingNameClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
                if (existingNameClaim != null)
                {
                    claimsIdentity.RemoveClaim(existingNameClaim);
                }

                // 添加新的Name Claim
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, userName));

                // 創建一個新的ClaimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // 使用新的ClaimsPrincipal來更新用戶的認證
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                // 完成上述步驟後，用戶的名稱Claim已更新，並且應用於當前的session或cookie中。
                return RedirectToAction(nameof(Profile)); // 重定向到 Profile 頁面
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(member.MemberId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //}

        }


        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.MemberId == id);
        }
    }
}
