using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Context : DbContext
    {
        public Context() :
           base(new SQLiteConnection()
           {
               ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "CompoundPermissions.db", ForeignKeys = true }.ConnectionString
           }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Rol>()
                .ToTable("Rol")
                .HasKey(r => r.RolId);
            modelBuilder.Entity<Permission>()
                .ToTable("Permission")
                .HasKey(p => p.PermissionId);
            modelBuilder.Entity<PermissionPermission>()
                .ToTable("PermissionPermission")
                .HasKey(x => new { x.PermissionId1, x.PermissionId2 });

            modelBuilder.Entity<User>().ToTable("User").HasKey(x => x.UserId);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Rol> Rols { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionPermission> PermissionPermission { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
