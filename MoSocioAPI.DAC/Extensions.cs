using MoSocioAPI.DTO;
using System.Linq;

namespace MoSocioAPI.DAC
{
    public static class Extensions
    {
        public static IQueryable<T> Paginated<T>(this IQueryable<T> source, PageInfoDto pageInfo)
        {
            return source
                .Skip((pageInfo.CurrentPage - 1) * pageInfo.RecordsPerPage)
                .Take(pageInfo.RecordsPerPage);
        }
    }
}
