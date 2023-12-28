using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LabMVC.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        [Display(Name = "Full Name")]
        public string NickName { get; set; }
        [Required]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string RePassword { get; set; }

        [RegularExpression(@"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$")]
        public string Mobile { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }
        public class Connection : DbContext
        {
            public DbSet<Account> Accounts { get; set; }
        }
    }
}