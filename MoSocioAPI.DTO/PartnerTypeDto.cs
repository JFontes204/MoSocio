using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class PartnerTypeDto
    {
        public int PartnerTypeId { get; set; }
        public string Label { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
