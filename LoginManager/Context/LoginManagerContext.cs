using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginManager.Models;
using LoginManager.Configurations;
using System.Configuration;
using Microsoft.Extensions.Configuration;
namespace LoginManager.Context
{
    public class LoginManagerContext : DbContext
    {
        public virtual DbSet<Kitchen> Kitchen { get; set; }
        public virtual DbSet<Frontend> Frontend { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Hotel_Manager.Properties.Settings.loginConnectionString"].ConnectionString);
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-G3N1PK3\\SQLEXPRESS;Initial Catalog=HMSLoginManager;Integrated Security=True;Encrypt=False;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.FrontendConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.KitchenConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
