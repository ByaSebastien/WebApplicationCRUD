using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCRUD.BLL.Exceptions
{
    public class UniqueConstraintException : Exception
    {
        public UniqueConstraintException(string message) : base(message) { }
    }
}
