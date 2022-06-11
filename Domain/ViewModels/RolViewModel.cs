using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class RolViewModel
    {
        public int RolId { get; set; }
        public string Description { get; set; }
        public CompoundPermissionViewModel Permission { get; set; } = new CompoundPermissionViewModel();
    }
}
