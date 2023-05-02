using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.BLL.DTO.Book;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.BLL.Mappers
{
    public static class BookMapper
    {
        public static Book ToDAL(this AddBookDTO book)
        {
            return new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
            };
        }
        public static Book ToDAL(this EditBookDTO book)
        {
            return new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
            };
        }
        public static EditBookDTO ToBLL(this Book book)
        {
            return new EditBookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ImagePath = book.Image ?? book.Image,
            };
        }
    }
}
