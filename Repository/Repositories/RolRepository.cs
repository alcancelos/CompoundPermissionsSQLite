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
            return _context.Rols.ToList();
        }
    }
}
