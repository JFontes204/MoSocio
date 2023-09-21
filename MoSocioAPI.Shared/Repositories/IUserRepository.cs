using InvoicingPlan.Model;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByLogin(string userName, string password);
    }
}
