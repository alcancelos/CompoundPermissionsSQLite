using Domain.ViewModels;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        RolRepository rolRepository = new RolRepository();
        public UserViewModel GetByLogon(string logon)
        {
            var user = userRepository.GetByLogon(logon);
            if(user!= null)
            {
                UserViewModel userVM = new UserViewModel();
                userVM.Logon=user.Logon;
                var rol = rolRepository.GetById(user.RolId);
                userVM.Rol = new RolViewModel()
                {
                    Description = rol.Description,
                    Permission = new CompoundPermissionViewModel()
                    {
                        Code = rol.PermissionId
                    },
                    RolId=rol.RolId,
                };
                return userVM;
            }

            return null;
        }
    }
}
