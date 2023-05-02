using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.BLL.Validators;

namespace WebApplicationCRUD.BLL.DTO.User
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Champs requis")]
        [MaxLength(50,ErrorMessage = "Taille maximum dépassée")]
        public string Pseudo { get; set; } = String.Empty;
        [Required(ErrorMessage = "Champs requis")]
        [MaxLength(150, ErrorMessage = "Taille maximum dépassée")]
        [EmailAddress(ErrorMessage = "Forma incorrect")]
        public string Email { get; set; } = String.Empty;
        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;
        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Les deux mot de passe doivent correspondre")]
        public string PasswordRepeat { get; set; } = String.Empty;
        [FileExtValidator("image/png", "image/jpg", "image/jpeg",ErrorMessage = "Fichier Invalid")]
        public IFormFile? Image { get; set; }
    }
}
