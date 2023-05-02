using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCRUD.BLL.DTO.User
{
    public class LoginUserDTO
    {
        [Required(ErrorMessage = "Champs requis")]
        public string Login { get; set; } = String.Empty;
        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;
    }
}
