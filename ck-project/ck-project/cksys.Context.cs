﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ck_project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ckdatabase : DbContext
    {
        public ckdatabase()
            : base("name=ckdatabase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<rates_installation> rates_installation { get; set; }
        public virtual DbSet<taxes_leads> taxes_leads { get; set; }
        public virtual DbSet<address> addresses { get; set; }
        public virtual DbSet<branch> branches { get; set; }
        public virtual DbSet<building_permit> building_permit { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<delivery_status> delivery_status { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<installation> installations { get; set; }
        public virtual DbSet<lead_log_file> lead_log_file { get; set; }
        public virtual DbSet<lead_source> lead_source { get; set; }
        public virtual DbSet<lead> leads { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<project_class> project_class { get; set; }
        public virtual DbSet<project_status> project_status { get; set; }
        public virtual DbSet<project_type> project_type { get; set; }
        public virtual DbSet<rate> rates { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<tasks_installation> tasks_installation { get; set; }
        public virtual DbSet<tax> taxes { get; set; }
        public virtual DbSet<total_cost> total_cost { get; set; }
        public virtual DbSet<users_types> users_types { get; set; }
        public virtual DbSet<archive_leads> archive_leads { get; set; }
    
        public virtual int LoginByUsernamePassword(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LoginByUsernamePassword", usernameParameter, passwordParameter);
        }
    }
}
