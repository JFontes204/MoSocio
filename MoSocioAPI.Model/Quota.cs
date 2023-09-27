using System;

namespace MoSocioAPI.Model
{
    public class Quota
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
