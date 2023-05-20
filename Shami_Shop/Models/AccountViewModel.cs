using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shami_Shop.Models
{

    public class RegisterViewModel
    {
        public static Random r = new Random();

        [MaxLength(11)]
        [Phone]
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public string MobilePhone { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(5)]
        [DataType(DataType.Password)]
        [Display(Name = "(رمز یکبار مصرف)کلمه عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "عدد رندوم")]
        public string randomnumber { get; set; } = r.Next(10000).ToString();
    }

    public class LoginViewModel
    {
        public static Random r = new Random();
        public string number = r.Next(10000).ToString();


        [MaxLength(11)]
        [Phone]
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(5)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "عدد رندوم")]
        public string randomnumber
        {
            get { return number; }
            set { number = value; }
        }

        [Display(Name = "مرا به خاطر بسپار ")]
        public bool RememberMe { get; set; }
    }

}
