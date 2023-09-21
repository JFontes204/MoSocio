using InvoicingPlan.Model;
using MoSocioAPI.Shared.Repositories;
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

        public User GetUserByLogin(string userName, string password)
        {
            //TODO hasserar a passWord ou então a password já será passada aqui como hash
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName 
                                && x.Password == password);
            if (user is null)
                return null;
            return user;
        }
    }
}
