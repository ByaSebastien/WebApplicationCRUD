using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.DAL.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public IEnumerable<Book>? GetFavorite(Guid id);
    }
}
