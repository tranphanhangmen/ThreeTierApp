using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessObject
{
    public class Account : LabObject
    {
        [StringLength(30)]
        //[Remote("NickNameExists", "Account", ErrorMessage = "Name already in use")]
        [Required(ErrorMessage = "Place Name is required")]
        [Display(Name = "Full Name")]
        public string NickName { get; set; }

        [StringLength(100),]
        [Required]
        //[Remote("EmailExists", "Account", ErrorMessage = "Email already in use")]
        //[RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Email has invalid syntax")]
        public string Email { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{6,}$", ErrorMessage = "Password must have at least 6 characters, upper and lower case letters, numbers and special characters")]
        [Required]
        //[DataType(DataType.Password)]       
        public string Password { get; set; }

        

        //[RegularExpression(@"(?<=^| )([-+]?\d+\.?(?:\d+)?)(?= |$)", ErrorMessage = "Mobile has invalid syntax")]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        public int Sex { get; set; }

        [StringLength(10)]       
        public string Status { get; set; }

        public virtual List<WorkItem> Works { get; set; }
    }
}