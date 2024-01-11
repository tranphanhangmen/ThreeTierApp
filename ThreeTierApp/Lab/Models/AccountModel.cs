using BussinessObject;
using System.ComponentModel.DataAnnotations;

namespace Lab.Models
{
    public class AccountModel : Account
    {
        [StringLength(50)]
        [Required]
        //[DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string RePassword { get; set; }
    }
}