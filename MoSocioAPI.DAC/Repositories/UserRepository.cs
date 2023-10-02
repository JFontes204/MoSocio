using InvoicingPlan.Model;
using MoSocioAPI.Shared.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MoSocioAPI.DAC.Repositories
{
    public  class UserRepository: BaseRepository<User>, IUserRepository
    {
        private readonly MoSocioAPIDbContext _context;
        public UserRepository(MoSocioAPIDbContext context)
            : base(context)
        { 
            _context = context;
        }

        public IEnumerable<User> GetAllUserWithRole()
        {
           return _context.Users.Include(r=>r.Roles);
        }

        public User GetUserByLogin(string userName, string password)
        {
            var userWithRole = _context.Users.Where(x => x.UserName == userName
                                && x.Password == password).Include(u=>u.Roles)
                                .FirstOrDefault();
            if (userWithRole is null)
                return null;
            return userWithRole;
        }
    }
}
