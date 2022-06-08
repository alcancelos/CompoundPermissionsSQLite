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

        public List<RolViewModel> GetAll()
        {
           var rols=rolRepository.GetAll();
            var list = new List<RolViewModel>();
            foreach(var r in rols)
            {
                var rolVM = new RolViewModel();
                rolVM.Description=r.Description;
                list.Add(rolVM);
            }
            return list;
        }
        
    }
}
