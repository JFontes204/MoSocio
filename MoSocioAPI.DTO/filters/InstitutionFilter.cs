using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class InstitutionFilter : PageInfoDto
    {
        public int? InstitutionId { get; set; }
        public string Name { get; set; }
        public InstitutionType InstitutionType { get; set; }
        public bool All { get; set; }
    }
}
