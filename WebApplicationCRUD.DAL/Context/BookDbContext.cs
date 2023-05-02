using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.DAL.Configurations;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.DAL.Context
{
    public class BookDbContext : DbContext
    {
        DbSet<User> Users => Set<User>();
        DbSet<Book> Books => Set<Book>();
        DbSet<Favorite> Favorites => Set<Favorite>();
        public BookDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new FavoriteConfiguration());
        }
    }
}
