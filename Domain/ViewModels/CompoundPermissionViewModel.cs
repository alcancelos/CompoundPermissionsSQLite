using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CompoundPermissionViewModel : PermissionViewModel
    {
        public List<PermissionViewModel> ListPermissions { get; set; } = new List<PermissionViewModel>();
        public List<PermissionViewModel> ListAux { get; set; }=new List<PermissionViewModel>();

        public CompoundPermissionViewModel(int pCode, string pDescription) : base(pCode, pDescription)
        {

        }
        public CompoundPermissionViewModel()
        {

        }

        public override List<PermissionViewModel> GetPermissions()
        {

            return ListPermissions;
        }

    }
}
