using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMenu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Price).HasPrecision(5, 2).IsRequired();
            builder.Property(x => x.Info).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.HasOne(x => x.Category).WithMany(c => c.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.User).WithMany(x=>x.Products).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.UserId).IsRequired(false);
            builder.Property(x => x.CategoryId).IsRequired(false);
          
        }
    }
}
