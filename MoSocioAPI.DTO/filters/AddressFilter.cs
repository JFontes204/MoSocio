using TypeLite;
using MoSocioAPI.Model.Configuration;
using System;
using MoSocioAPI.Model;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class AddressFilter : PageInfoDto
    {
        public int? AddressId { get; set; }
        public Partner Partner { get; set; }
        public Institution Institution { get; set; }
        public bool All { get; set; }
    }
}
