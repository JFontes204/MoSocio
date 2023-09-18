using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using System;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class QuotaDto
    {
        public int QuotaId { get; set; }
        public string Value { get; set; }
        public DateTime DateCreation { get; set; }
        public int QuotaTypeId { get; set; }
        public QuotaType QuotaType { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
