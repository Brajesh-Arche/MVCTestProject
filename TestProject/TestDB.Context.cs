﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MVCTestEntities2 : DbContext
    {
        public MVCTestEntities2()
            : base("name=MVCTestEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Country_Table> Country_Table { get; set; }
        public virtual DbSet<State_Table> State_Table { get; set; }
        public virtual DbSet<User_SignUp_Table> User_SignUp_Table { get; set; }
        public virtual DbSet<City_Table> City_Table { get; set; }
        public virtual DbSet<Orgnization_Table> Orgnization_Table { get; set; }
    }
}
