using InvoicingPlan.Model;
using System.Collections.Generic;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByLogin(string userName, string password);

        IEnumerable<User> GetAllUserWithRole();
    }
}
