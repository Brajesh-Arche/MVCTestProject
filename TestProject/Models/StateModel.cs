using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class StateModel
    {
        [Key]
        public int StateId { get; set; }   
        [Required(ErrorMessage ="Please Enter State Name...")]
        [Display(Name ="State")]
        public string StateName { get; set; }
        public int countryId{get; set; }
    }
}