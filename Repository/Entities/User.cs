using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Logon { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public Rol Rol { get; set; }
    }
}
