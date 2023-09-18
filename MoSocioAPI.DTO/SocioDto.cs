using MoSocioAPI.Model.Configuration;
using System;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class SocioDto
    {
        public int SocioId { get; set; }
        public string NumeroSocio { get; set; }
        public DateTime DataRegisto { get; set; }

    }
}
