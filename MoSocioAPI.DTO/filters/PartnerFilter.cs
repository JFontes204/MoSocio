using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using System;
using TypeLite;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class PartnerFilter : PageInfoDto
    {
        public int? PartnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string PartnerNumber { get; set; }
        public string DocNumber { get; set; }
        public string Telefone { get; set; }
        public DateTime DateRegistration { get; set; }
        public PartnerType PartnerType { get; set; }
        public Institution Institution { get; set; }
        public bool All { get; set; }
    }
}
