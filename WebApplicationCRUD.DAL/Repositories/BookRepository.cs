using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.DAL.Context;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.DAL.Repositories
{
    public class BookRepository : BaseRepository<Book> , IBookRepository
    {
        public BookRepository(BookDbContext context) : base(context) { }
    }
}
