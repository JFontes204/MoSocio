using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class ProvinceDto
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
    }
}
