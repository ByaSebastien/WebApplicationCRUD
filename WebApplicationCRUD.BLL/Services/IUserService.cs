using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.BLL.DTO.User;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.BLL.Services
{
    public interface IUserService
    {
        public User Register(RegisterUserDTO user);
        public User Login(LoginUserDTO user);
        public User? GetOne(params object[] ids);
    }
}
