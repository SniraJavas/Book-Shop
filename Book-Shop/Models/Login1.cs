using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public partial class Login1
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        [MinLength(4, ErrorMessage = "User Name Minimum Length Should Be 4 Char")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password Minimum Length Should Be 6 Char")]
        public string Password { get; set; }

    }
}