using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }

     

    }
}
