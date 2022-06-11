using Domain.ViewModels;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PermissionService
    {
        RolRepository rolRepository = new RolRepository();

        public CompoundPermissionViewModel GetCompoundPermission(int pCode)
        {
            var permissions= rolRepository.GetAllPermissions();
            var permissionsPermissions = rolRepository.GetPermissionPermissions().Where(x=>x.PermissionId1==pCode);

            var cp = new CompoundPermissionViewModel();
            foreach(var p in permissionsPermissions)
            {
                if (permissions.Find(x => x.PermissionId == p.PermissionId2).Type == "PS")
                {
                    SimplePermissionViewModel simplePermission = new SimplePermissionViewModel();
                    simplePermission.Code = p.PermissionId2;
                    cp.ListPermissions.Add(simplePermission);
                }
                else
                {
                    CompoundPermissionViewModel compoundPermissionViewModel = new CompoundPermissionViewModel();    
                    compoundPermissionViewModel.Code = p.PermissionId2;
                    cp.ListPermissions.Add(compoundPermissionViewModel);
                }
            }
            return cp;  
        }

        public List<PermissionViewModel> GetPermissions(PermissionViewModel p)
        {

            //Puede haber permisos compuestos adentro de otros permisos compuestos
            //Ahi es donde actua la recursividad
            ((CompoundPermissionViewModel)p).ListAux.Clear();
            GetPermissionsRecursive(((CompoundPermissionViewModel)p).ListPermissions, ((CompoundPermissionViewModel)p).ListAux);

            return ((CompoundPermissionViewModel)p).ListAux;
        }
        private void GetPermissionsRecursive(List<PermissionViewModel> pList, List<PermissionViewModel> pListAux)
        {
            foreach (var p in pList)
            {
                if (p is SimplePermissionViewModel)
                {
                    pListAux.Add(p);
                }
                else
                {   //Aca tengo que mappear el contenido del permiso compuesto...


                    CompoundPermissionViewModel PC = GetCompoundPermission(p.Code);


                    GetPermissionsRecursive(GetComponents(PC), pListAux);

                }
            }

        }

        private List<PermissionViewModel> GetComponents(PermissionViewModel p)
        {
            return p.GetPermissions();
        }

        public bool Validate(int pCode, PermissionViewModel p)
        {
            return GetPermissions(p).Exists(x => x.Code == pCode);
        }
    }
}
