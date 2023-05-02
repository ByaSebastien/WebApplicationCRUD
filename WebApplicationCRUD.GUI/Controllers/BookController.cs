using Microsoft.AspNetCore.Mvc;
using WebApplicationCRUD.BLL.DTO.Book;
using WebApplicationCRUD.BLL.Mappers;
using WebApplicationCRUD.BLL.Services;
using WebApplicationCRUD.IL.Sessions;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.GUI.Controllers
{
    public class BookController : Controller
    {
        public IBookService _bookService { get; private set; }
        public SessionManager _session { get; private set; }

        public BookController(IBookService bookService, SessionManager session)
        {
            _bookService = bookService;
            _session = session;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetMany());
        }
        public IActionResult Detail(Guid id)
        {
            return View(_bookService.GetOne(id));
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddBookDTO book)
        {
            if (!ModelState.IsValid)
                return View(book);
            _bookService.Insert(book);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid id)
        {
            return View(_bookService.GetOne(id));
        }
        [HttpPost]
        public IActionResult Edit(EditBookDTO book)
        {
            if (!ModelState.IsValid)
                return View(book);
            _bookService.Update(book);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid id)
        {
            _bookService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddFavorite(Guid bookId)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
