using ReservationManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManager.Context
{
    public class ReservationContext : DbContext
    {
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-G3N1PK3\\SQLEXPRESS;Initial Catalog=HMSReservationManager;Integrated Security=True;Encrypt=False;");
    }
}
