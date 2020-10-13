using SSEPS.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace SSEPS.Repository
{
    public class EmployeeEntityConfiguration: EntityTypeConfiguration<Employee>
    {
        public EmployeeEntityConfiguration()
        {
            //this.HasOptional(e => e.Manager)
            //    .WithMany()
            //    .HasForeignKey(e => e.ManagerId);

            //this.Entity<EmployeeRole>()
            //    .HasKey(er => new { er.EmployeeId, er.RoleId });

            //this.Entity<EmployeeRole>()
            //    .HasOne<Employee>(e => e.Employee)
            //    .WithMany(er => er.EmployeeRoles)
            //    .HasForeignKey(r => r.EmployeeId);

            //this.Entity<EmployeeRole>()
            //    .HasOne<Role>(r => r.Role)
            //    .WithMany(er => er.EmployeeRoles)
            //    .HasForeignKey(r => r.RoleId);
        }
    }
}
