using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCRUD.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
