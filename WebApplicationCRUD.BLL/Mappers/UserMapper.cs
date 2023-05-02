using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.BLL.DTO.User;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.BLL.Mappers
{
    public static class UserMapper
    {
        public static User ToDAL(this RegisterUserDTO user)
        {
            return new User()
            {
                Pseudo = user.Pseudo,
                Email = user.Email,
                Image = user.Image is null? null : user.Image.FileName,                
            };
        }
    }

}

