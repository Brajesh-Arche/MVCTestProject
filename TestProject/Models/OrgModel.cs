using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class OrgModel
    {
        public int OrgId { get; set; }
        [Required(ErrorMessage ="Please enter Organization Name....")]
        [Display(Name ="Organization Name")]
        public string OrganizationName { get; set; }
        [Required(ErrorMessage = "Please enter Website....")]
        
        [DataType(DataType.Url)]
        public string Website { get; set; }
        public string Specialities { get; set; }
        [Display(Name ="No Of Employee")]
        public int NoOFEmployee { get; set; }
        [Required(ErrorMessage ="Please Select Country...")]
        [Display(Name = "Country Name")]
        public int CountryId { get; set; }
        [Display(Name = "State Name")]
        public int StateId { get; set; }
        [Display(Name = "City Name")]
        public int CityId { get; set; }
        [Display(Name = "Address")]
        public string Addresss { get; set; }
        [Display(Name = "Office Phone")]
        [DataType(DataType.PhoneNumber)]
        public long OfficePhone { get; set; }    
        [Display(Name ="Mobile No")]
        [DataType(DataType.PhoneNumber)]
        public long MobileNo { get; set; }
        [Display(Name ="LinkedIn Url")]
        public string LinkedinURL { get; set; }
        public bool IsActive { get; set; }
    }
}