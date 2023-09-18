using TypeLite;
using MoSocioAPI.Model.Configuration;
using System;
using MoSocioAPI.Model;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class ContactFilter : PageInfoDto
    {
        public int? ContactId { get; set; }
        public string Label { get; set; }
        public ContactType ContactType { get; set; }
        public Partner Partner { get; set; }
        public Institution Institution { get; set; }
        public bool All { get; set; }
    }
}
