using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class InstitutionTypeFilter : PageInfoDto
    {
        public int? InstitutionTypeId { get; set; }
        public string Label { get; set; }
        public bool All { get; set; }
    }
}
