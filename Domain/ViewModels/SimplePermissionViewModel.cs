using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class SimplePermissionViewModel: PermissionViewModel
    {
        public SimplePermissionViewModel(int pCode, string pDescription) : base(pCode, pDescription)
        {

        }
        public SimplePermissionViewModel()
        {

        }

        public override List<PermissionViewModel> GetPermissions()
        {
            //retorna este permiso
            return new List<PermissionViewModel>() { this };
        }
    }
}
