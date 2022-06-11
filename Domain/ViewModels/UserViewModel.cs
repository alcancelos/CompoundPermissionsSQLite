using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class UserViewModel
    {
        public string Logon { get; set; }
        public string Name { get; set; }
        public RolViewModel Rol { get; set; }
    }
}
