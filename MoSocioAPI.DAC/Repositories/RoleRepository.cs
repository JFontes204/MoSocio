using InvoicingPlan.Model;
using MoSocioAPI.Shared.Repositories;

namespace MoSocioAPI.DAC.Repositories
{
    public class RoleRepository: BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(MoSocioAPIDbContext context)
            : base(context)
        {
        }
    }
}
