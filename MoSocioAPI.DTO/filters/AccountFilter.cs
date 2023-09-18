using TypeLite;
using MoSocioAPI.Model.Configuration;
using System;
using MoSocioAPI.Model;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class AccountFilter : PageInfoDto
    {
        public int? AccountId { get; set; }
        public string Username { get; set; }
        public Partner Partner { get; set; }
        public bool All { get; set; }
    }
}
