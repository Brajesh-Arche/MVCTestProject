//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orgnization_Table
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Website { get; set; }
        public string Specialities { get; set; }
        public Nullable<int> NoOFEmployee { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Addresss { get; set; }
        public Nullable<decimal> OfficePhone { get; set; }
        public Nullable<decimal> MobileNo { get; set; }
        public string LinkedinURL { get; set; }
    }
}
