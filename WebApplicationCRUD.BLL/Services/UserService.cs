using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.BLL.DTO.User;
using WebApplicationCRUD.BLL.Exceptions;
using WebApplicationCRUD.BLL.Mappers;
using WebApplicationCRUD.DAL.Repositories;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.BLL.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository { get; private set; }
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Register(RegisterUserDTO user)
        {
            User? testUser = _userRepository.GetOne(u => u.Pseudo == user.Pseudo || u.Email == user.Email);
            if (testUser is not null)
                throw new UniqueConstraintException("Already exist");
            User newUser = user.ToDAL();
            newUser.Id = Guid.NewGuid();
            newUser.Password = Argon2.Hash(user.Password);
            if (user.Image is not null)
            {
                newUser.Image = user.Image.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                if(!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string fileNameWithPath = Path.Combine(path, user.Image.FileName);
                using(FileStream fs = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    user.Image.CopyTo(fs);
                }
            }
            return _userRepository.Insert(newUser);
        }
        public User Login(LoginUserDTO user)
        {
            User? newUser = _userRepository.GetOne(u => u.Pseudo == user.Login || u.Email == user.Login);
            if (newUser is null)
                throw new KeyNotFoundException();
            if (!Argon2.Verify(newUser.Password, user.Password))
                throw new WrongPasswordException("Wrong password");
            return newUser;            
        }

        public User? GetOne(params object[] ids)
        {
            return _userRepository.GetOne(ids);
        }
    }
}
