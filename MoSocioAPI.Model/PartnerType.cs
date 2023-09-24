using System.Collections.Generic;

namespace MoSocioAPI.Model
{
    public class PartnerType
    {
        public int PartnerTypeId { get; set; }
        public string Label { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public List<Partner> Partners { get; set; }
    }
}
