using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class PageInfoDto
    {
        public int Records { get; set; }
        public int RecordsPerPage { get; set; } = 1;
        public int CurrentPage { get; set; }

        public int PageCount
        {
            get { return (Records + RecordsPerPage - 1) / RecordsPerPage; }
        }
    }
}
