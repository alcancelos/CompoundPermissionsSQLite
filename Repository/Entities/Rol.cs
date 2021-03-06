using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Description { get; set; }
        public int PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }
    }
}
