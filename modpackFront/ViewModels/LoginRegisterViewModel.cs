using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using modpackFront.DTO; // 確保 LoginDTO 在這個命名空間下

namespace modpackFront.ViewModels
{
    public class LoginRegisterViewModel
    {
        // 登入部分
        public LoginDTO Login { get; set; }

        // 註冊部分
        [DisplayName("會員等級")]
        public int LevelId { get; set; } = 1; // 對應為新註冊會員

        [Required]
        [StringLength(16, ErrorMessage = "帳號長度必須在16個字符以內")]
        [DisplayName("帳號")]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("密碼")]
        public string Password { get; set; }

        // 新增密碼確認屬性
        //[Required]
        //[DataType(DataType.Password)]
        //[DisplayName("密碼確認")]
        //[Compare("Password", ErrorMessage = "密碼和密碼確認不相同。")]
        //public string ConfirmPassword { get; set; }

        [StringLength(8, ErrorMessage = "名稱必須在8個字符以內")]
        [DisplayName("名稱")]
        public string Name { get; set; }

        [EmailAddress]
        [DisplayName("電子郵件")]
        public string Email { get; set; }

        //[Phone]
        //[DisplayName("電話")]
        //public string Phone { get; set; }

        //[StringLength(100)]
        //[DisplayName("地址")]
        //public string Address { get; set; }
    }
}
