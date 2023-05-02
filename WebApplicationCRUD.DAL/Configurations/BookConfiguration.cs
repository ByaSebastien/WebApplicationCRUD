using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.DAL.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasIndex(b => b.Title).IsUnique();
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Title).HasMaxLength(100);

            builder.Property(b => b.Author).IsRequired();
            builder.Property(b => b.Author).HasMaxLength(100);

            builder.Property(b => b.Description).HasMaxLength(500);

            builder.HasIndex(b => b.Image).IsUnique();
        }
    }
}
