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
            modelBuilder.Entity<Rol>().ToTable("Rol").HasKey(e => e.RolId);
           

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Rol> Rols { get; set; }
    }
}
