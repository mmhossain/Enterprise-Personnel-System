using Microsoft.EntityFrameworkCore;
using SSEPS.Domain;

namespace SSEPS.Repository {

    public class EmployeeDataContext : DbContext {

        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> opts)
            : base(opts) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ERole> ERoles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(e => e.ManagerId);

            modelBuilder
                .Entity<EmployeeRole>()
                .HasKey(er => new { er.EmployeeId, er.ERoleId });

            modelBuilder
                .Entity<EmployeeRole>()
                .HasOne<Employee>(e => e.Employee)
                .WithMany(er => er.EmployeeRoles)
                .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<EmployeeRole>()
                .HasOne<ERole>(r => r.ERole)
                .WithMany(er => er.EmployeeRoles)
                .HasForeignKey(r => r.ERoleId);

            //modelBuilder.ApplyConfiguration<EmployeeEntityConfiguration>(new EmployeeEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
