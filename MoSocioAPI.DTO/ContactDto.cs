using TypeLite;
using MoSocioAPI.Model.Configuration;
using System;
using MoSocioAPI.Model;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string Label { get; set; }
        public int ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
