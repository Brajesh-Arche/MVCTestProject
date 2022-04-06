using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        [Required (ErrorMessage ="Please enetr country...")]
        [Display(Name ="Country")]
        public string CountryName { get; set; }
    }
}