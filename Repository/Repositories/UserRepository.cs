using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository
    {
        Context _context = new Context();
        public User GetByLogon(string logon)
        {
            return _context.Users.FirstOrDefault(x => x.Logon == logon);
        }
    }
}
