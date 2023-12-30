namespace LabMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        [Required(ErrorMessage = "Place Name is required")]
        [Display(Name = "Full Name")]
        public string NickName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100),]
        [Required]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*")]
        public string Email { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50, MinimumLength = 6)]
        [Required]
        //[DataType(DataType.Password)]       
        public string Password { get; set; }

        [NotMapped]
        [StringLength(50, MinimumLength = 6)]
        [Required]
        //[DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [RegularExpression(@"(?<=^| )([-+]?\d+\.?(?:\d+)?)(?= |$)")]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        public byte? Sex { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string Status { get; set; }
    }
}
