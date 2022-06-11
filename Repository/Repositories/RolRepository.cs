using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class RolRepository
    {
        Context _context = new Context();
        public List<Rol> GetAll()
        {
            return _context.Rols.Include("Permission").ToList();
        }

        public Rol GetById(int id)
        {
            return _context.Rols.AsNoTracking().Include("Permission").Where(x=>x.RolId==id).FirstOrDefault();
        }

        public List<PermissionPermission> GetPermissionPermissions()
        {
            return _context.PermissionPermission.ToList();
        }

        public List<Permission> GetAllPermissions()
        {
            return _context.Permissions.ToList();
        }

        
    }
}
