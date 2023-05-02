using Microsoft.AspNetCore.Mvc;
using WebApplicationCRUD.BLL.DTO.User;
using WebApplicationCRUD.BLL.Services;
using WebApplicationCRUD.GUI.Models;
using WebApplicationCRUD.IL.Sessions;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.GUI.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private SessionManager _sessionManager;

        public UserController(IUserService userService, SessionManager sessionManager)
        {
            _userService = userService;
            _sessionManager = sessionManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterUserDTO user)
        {
            if (!ModelState.IsValid)
                return View(user);
            try
            {
            _userService.Register(user);
            }
            catch(Exception)
            {
                return View(user);
            }
            return RedirectToAction(nameof(Index),"Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUserDTO user)
        {
            if (!ModelState.IsValid)
                return View(user);
            try
            {
                User Result = _userService.Login(user);
                _sessionManager.CurrentUser = new UserSession(Result);
            }
            catch (Exception)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Book");
        }
        public IActionResult Logout()
        {
            _sessionManager.Logout();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Detail()
        {
            User user = _userService.GetOne(_sessionManager.CurrentUser.Id);
            return View(user);
        }
    }
}
