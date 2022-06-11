using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public abstract class PermissionViewModel
    {
        public int Code { get; set; }
        public string Description { get; set; }


        public PermissionViewModel(int pCode, string pDescription)
        {
            Code = pCode;
            Description = pDescription;
        }

        public PermissionViewModel()
        {

        }

        public abstract List<PermissionViewModel> GetPermissions();
    }
}
