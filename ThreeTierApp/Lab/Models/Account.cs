using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Models
{
    public class Account
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        //[Remote("NickNameExists", "Account", ErrorMessage = "Name already in use")]
        [Required(ErrorMessage = "Place Name is required")]
        [Display(Name = "Full Name")]
        public string NickName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100),]
        [Required]
        //[Remote("EmailExists", "Account", ErrorMessage = "Email already in use")]
        //[RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Email has invalid syntax")]
        public string Email { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{6,}$", ErrorMessage = "Password must have at least 6 characters, upper and lower case letters, numbers and special characters")]
        [Required]
        //[DataType(DataType.Password)]       
        public string Password { get; set; }

        [NotMapped]
        [StringLength(50)]
        [Required]
        //[DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string RePassword { get; set; }

        //[RegularExpression(@"(?<=^| )([-+]?\d+\.?(?:\d+)?)(?= |$)", ErrorMessage = "Mobile has invalid syntax")]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        public int Sex { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]       
        public string Status { get; set; }

    }
}