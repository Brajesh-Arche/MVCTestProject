using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please Provide User Name")]
        [DataType(DataType.Text)]
        [Display(Name ="Full Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please Provide Email Address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please Enter a Valid Email Address.")]
        [Display(Name ="Email")]
        public string UserMail { get; set; }
    }
}