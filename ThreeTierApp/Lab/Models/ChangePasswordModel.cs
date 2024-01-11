using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab.Models
{
    public class ChangePasswordModel
    {
        [StringLength(50)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{6,}$", ErrorMessage = "Password must have at least 6 characters, upper and lower case letters, numbers and special characters")]
        [Required]
        //[DataType(DataType.Password)]       
        public string Password { get; set; }
        
        [StringLength(50)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{6,}$", ErrorMessage = "Password must have at least 6 characters, upper and lower case letters, numbers and special characters")]
        [Required]
        //[DataType(DataType.Password)]       
        public string NewPassword { get; set; }
        [NotMapped]
        [StringLength(50)]
        [Required]
        //[DataType(DataType.Password)] 
        [Compare("NewPassword")]
        public string RePassword { get; set; }
    }
}