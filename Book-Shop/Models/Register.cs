using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class Users : Login1
    {
       
        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        [MinLength(4, ErrorMessage = "First Name Minimum Length Should Be 4 Char")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        [MinLength(4, ErrorMessage = "Last Name Minimum Length Should Be 4 Char")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }
}