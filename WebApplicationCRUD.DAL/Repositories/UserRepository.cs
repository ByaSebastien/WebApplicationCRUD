using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.DAL.Context;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookDbContext context) : base(context) { }
        public IEnumerable<Book>? GetFavorite(Guid userId)
        {
            return _entities.Include(u => u.Favorites).ThenInclude(f => f.Book).SingleOrDefault(u => u.Id == userId)?.Favorites.Select(f => f.Book);
        }
    }
}
