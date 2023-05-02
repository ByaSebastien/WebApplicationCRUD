using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.BLL.DTO.Book;
using WebApplicationCRUD.BLL.Exceptions;
using WebApplicationCRUD.BLL.Mappers;
using WebApplicationCRUD.DAL.Repositories;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.BLL.Services
{
    public class BookService : IBookService
    {
        public IBookRepository _bookRepository { get; private set; }
        public IUserRepository _userRepository { get; private set; }
        public BookService(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }
        public Book Delete(Guid id)
        {
            Book? book = _bookRepository.GetOne(id);
            if (book is null)
                throw new KeyNotFoundException();
            return _bookRepository.Delete(book);
        }

        public IEnumerable<Book> GetMany()
        {
            return _bookRepository.GetMany();
        }

        public Book? GetOne(Guid id)
        {
            return _bookRepository.GetOne(id);
        }

        public Book Insert(AddBookDTO book)
        {
            if (book == null)
                throw new ArgumentNullException();
            if (_bookRepository.Any(b => b.Title == book.Title))
                throw new UniqueConstraintException("Already exist");
            Book newBook = book.ToDAL();
            newBook.Id = Guid.NewGuid();
            if (book.Image is not null)
            {
                newBook.Image = book.Image.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string fileNameWithPath = Path.Combine(path, book.Image.FileName);
                using (FileStream fs = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    book.Image.CopyTo(fs);
                }
            }
            return _bookRepository.Insert(newBook);
        }

        public Book Update(EditBookDTO book)
        {
            if (book == null)
                throw new ArgumentNullException();
            if (!_bookRepository.Any(b => b.Id == book.Id))
                throw new KeyNotFoundException();
            Book newBook = book.ToDAL();
            newBook.Id = book.Id;
            if (book.Image is not null)
            {
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/{book.ImagePath}")))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory() + $"wwwroot/Images/{book.ImagePath}"));
                newBook.Image = book.Image.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string fileNameWithPath = Path.Combine(path, book.Image.FileName);
                using (FileStream fs = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    book.Image.CopyTo(fs);
                }
            }
            else
                newBook.Image = book.ImagePath;
            return _bookRepository.Update(newBook);
        }

        public IEnumerable<Book>? GetFavorite(Guid id)
        {
            if (!_userRepository.Any(u => u.Id == id))
                throw new KeyNotFoundException();
            return _userRepository.GetFavorite(id);
        }
    }
}