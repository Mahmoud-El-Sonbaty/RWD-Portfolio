using LoginManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManager.Configurations
{
    public class KitchenConfiguration : IEntityTypeConfiguration<Kitchen>
    {
        public void Configure(EntityTypeBuilder<Kitchen> entity)
        {
            entity.HasKey(e => e.Username);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(12);
        }
    }
}
