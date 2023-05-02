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
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasOne(f => f.User).WithMany(u => u.Favorites).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.Book).WithMany(b => b.Favorites).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
