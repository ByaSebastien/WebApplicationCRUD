using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.GUI.Models
{
    public class UserSession
    {
        public UserSession() { }
        public UserSession(User user)
        {
            Id = user.Id;
            Pseudo = user.Pseudo;
        }
        public Guid Id { get; set; }
        public string Pseudo { get; set; } = String.Empty;
    }
}
