using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.BLL.Validators;

namespace WebApplicationCRUD.BLL.DTO.Book
{
    public class AddBookDTO
    {
        [Required(ErrorMessage = "Champs requis")]
        [MaxLength(100, ErrorMessage = "Taille maximum dépassée")]
        public string Title { get; set; } = String.Empty;
        [Required(ErrorMessage = "Champs requis")]
        [MaxLength(100, ErrorMessage = "Taille maximum dépassée")]
        public string Author { get; set; } = String.Empty;
        [MaxLength(500, ErrorMessage = "Taille maximum dépassée")]
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
