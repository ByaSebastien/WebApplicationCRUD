using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplicationCRUD.GUI.Models;
using WebApplicationCRUD.Models.Entities;

namespace WebApplicationCRUD.IL.Sessions
{
    public class SessionManager
    {
        private readonly ISession? _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public UserSession CurrentUser
        {
            get
            {
                if (_session.GetString("user") is not null)
                {
                    return JsonSerializer.Deserialize<UserSession>(_session.GetString("user"));
                }
                return null;
            }
            set
            {
                _session.SetString("user", JsonSerializer.Serialize(value));
            }
        }
        public void Logout()
        {
            CurrentUser = null;
        }
    }
}