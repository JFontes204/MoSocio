using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class SociosFilter : PageInfoDto
    {
        public int? SocioId { get; set; }
        public string NumeroSocio { get; set; }
        public bool All { get; set; }
    }
}
