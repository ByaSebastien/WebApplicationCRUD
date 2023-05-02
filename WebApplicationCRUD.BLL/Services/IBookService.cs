using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.BLL.DTO.Book;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.BLL.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetMany();
        Book? GetOne(Guid id);
        Book Insert(AddBookDTO entity);
        Book Update(EditBookDTO entity);
        Book Delete(Guid id);
        public IEnumerable<Book>? GetFavorite(Guid id);
    }
}
