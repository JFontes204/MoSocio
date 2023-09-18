using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class QuotaFilter : PageInfoDto
    {
        public int? QuotaId { get; set; }
        public string Value { get; set; }
        public QuotaType QuotaType { get; set; }
        public Partner Partner { get; set; }
        public Institution Institution { get; set; }
        public bool All { get; set; }
    }
}
