using Domain.ViewModels;
using Repository;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RolService
    {
        RolRepository rolRepository = new RolRepository();
        PermissionService compoundPermissionService = new PermissionService();  
        public RolViewModel GetRol(int id)
        {
            var rol=rolRepository.GetById(id);
            var permissions = rolRepository.GetAllPermissions();
            var permissionsPermissions = rolRepository.GetPermissionPermissions();

            var rolVM = new RolViewModel();
            rolVM.RolId = rol.RolId;
            rolVM.Description = rol.Description;
            rolVM.Permission.Description = rol.Permission.Description;
            rolVM.Permission.Code = rol.Permission.PermissionId;
            //Recorro la taba permissionPermission

            foreach (var p in permissionsPermissions)
            {
                if (p.PermissionId1 == rol.PermissionId)
                {
                    //tengo que fijarme si es simple o compuesto
                    var per = permissions.Find(x => x.PermissionId == p.PermissionId2);
                    if (per.Type == "PS")
                    {
                        //si es simple lo agrego
                        SimplePermissionViewModel simplePermissionViewModel = new SimplePermissionViewModel();
                        simplePermissionViewModel.Description = per.Description;
                        simplePermissionViewModel.Code = per.PermissionId;
                        rolVM.Permission.ListPermissions.Add(simplePermissionViewModel);
                    }
                    else
                    {
                        //si es compuesto 
                        CompoundPermissionViewModel compoundPermissionViewModel = new CompoundPermissionViewModel();
                        compoundPermissionViewModel.Description = per.Description;
                        compoundPermissionViewModel.Code = per.PermissionId;
                        rolVM.Permission.ListPermissions.Add(compoundPermissionViewModel);
                    }
                }
            }
           
            return rolVM;
        }

      

    }
}
