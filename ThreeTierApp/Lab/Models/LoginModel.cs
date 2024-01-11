using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Models
{
    public class LoginModel
    {
        [StringLength(100)]
        [Required]
        //[Remote("EmailExists", "Account", ErrorMessage = "Email already in use")]
        //[RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Email has invalid syntax")]
        public string Email { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{6,}$", ErrorMessage = "Password must have at least 6 characters, upper and lower case letters, numbers and special characters")]
        [Required]
        //[DataType(DataType.Password)]       
        public string Password { get; set; }
    }
}