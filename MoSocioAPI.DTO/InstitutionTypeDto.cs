using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class InstitutionTypeDto
    {
        public int InstitutionTypeId { get; set; }
        public string Label { get; set; }
    }
}
