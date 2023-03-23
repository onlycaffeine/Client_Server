using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSDL_Nangcao.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = " ")]
        //[Required]
        public string UserName { set; get; }

        //[Required(ErrorMessage = "Mời nhập password")]
        //[Required]
        public string Password { set; get; }
    }
}