using TypeLite;
using MoSocioAPI.Model.Configuration;
using System;
using MoSocioAPI.Model;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class ContactTypeFilter : PageInfoDto
    {
        public int? ContactTypeId { get; set; }
        public string Label { get; set; }
        public bool All { get; set; }
    }
}
