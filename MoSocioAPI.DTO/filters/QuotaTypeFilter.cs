using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class QuotaTypeFilter : PageInfoDto
    {
        public int? QuotaTypeId { get; set; }
        public string Label { get; set; }
        public Institution Institution { get; set; }
        public bool All { get; set; }
    }
}
