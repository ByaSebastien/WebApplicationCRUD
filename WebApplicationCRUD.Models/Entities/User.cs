using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCRUD.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Pseudo { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string? Image { get; set; }
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
